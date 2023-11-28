using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reflection.Metadata;

namespace Infrastructure.Test
{
    internal class TestDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider, IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        internal TestDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestDbAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute(expression));
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression));
        }

        TResult IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression)).Result;
        }
    }

    internal class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public TestDbAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        public IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<T>(this); }
        }
    }

    internal class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public TestDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_inner.MoveNext());
        }

        public T Current
        {
            get { return _inner.Current; }
        }

        object IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }

    public class ProductRepositoryTest
    {
        private ProductDbContext MockDatabaseContext()
        {
            var data = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Description = "Test description 1",
                    ImgUri = @"D:\images\test",
                    Name = "Test product 1",
                    Price = 1000
                },
                new Product
                {
                    Id = 2,
                    Description = "Test description 2",
                    ImgUri = @"D:\images\test",
                    Name = "Test product 2",
                    Price = 3
                },
                new Product
                {
                    Id = 3,
                    Description = "Test description 3",
                    ImgUri = @"D:\images\test",
                    Name = "Test product 3",
                    Price = 59870
                },
                new Product
                {
                    Id = 4,
                    Description = "Test description 4",
                    ImgUri = @"D:\images\test",
                    Name = "Test product 4",
                    Price = 548
                },
                new Product
                {
                    Id = 5,
                    Description = "Test description 5",
                    ImgUri = @"D:\images\test",
                    Name = "Test product 5",
                    Price = 213
                },
                new Product
                {
                    Id = 6,
                    Description = "Test description 6",
                    ImgUri = @"D:\images\test",
                    Name = "Test product 6",
                    Price = 6000
                },
                new Product
                {
                    Id = 7,
                    Description = "Test description 7",
                    ImgUri = @"D:\images\test",
                    Name = "Test product 7",
                    Price = 1123
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IDbAsyncEnumerable<Product>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Product>(data.GetEnumerator()));
            mockSet.As<IQueryable<Product>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Product>(data.Provider));

            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<ProductDbContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            return mockContext.Object;
        }

        [Fact]
        public async Task GetById_AlwaysWorks()
        {
            // Arrange
            var productDbContextMock = MockDatabaseContext();
            var productRepository = new ProductRepository(productDbContextMock);

            // Act
            var item1 = await productRepository.GetById(1);
            var item2 = await productRepository.GetById(2);
            var item3 = await productRepository.GetById(3);
            var item4 = await productRepository.GetById(0);

            // Asset
            Assert.Equal(1000, item1.Price);
            Assert.Equal(3, item2.Price);
            Assert.Equal(59870, item3.Price);
            Assert.Null(item4.Price);
        }

        [Fact]
        public async Task GetAll_AlwaysWorks()
        {
            // Arrange
            var productDbContextMock = MockDatabaseContext();
            var productRepository = new ProductRepository(productDbContextMock);

            // Act
            var items = await productRepository.GetAll();

            // Asset
            Assert.Equal(7, items.Count);
        }
    }
}