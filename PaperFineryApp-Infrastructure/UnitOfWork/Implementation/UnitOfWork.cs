using Microsoft.EntityFrameworkCore;
using PaperFineryApp_Infrastructure.Persistence;
using PaperFineryApp_Infrastructure.Repository.Abstraction;
using PaperFineryApp_Infrastructure.Repository.Implementation;
using PaperFineryApp_Infrastructure.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Infrastructure.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _Context;
        private IManufacturerRepository _manufacturerRepository;
        private ISupplierRepository _supplierRepository;
        private IOrderRepository _orderRepository;
        private IReviewRepository _reviewRepository;
        
        public UnitOfWork(AppDbContext context)
        {
            _Context = context;
        }
        public IManufacturerRepository ManufacturerRepository => _manufacturerRepository??= new ManufacturerRepository(_Context);
        public ISupplierRepository SupplierRepository => _supplierRepository ??= new SupplierRepository(_Context);
        public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(_Context);
        public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(_Context);
        public async Task SaveChangesAsync ()
        {
            await _Context.SaveChangesAsync();
        }
    }
}