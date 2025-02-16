﻿using System.Net.Http.Headers;
using ClassLibrary.Context;
using ClassLibrary.Entities;
using ClassLibrary.Repositories.BookRepositories;
using ClassLibrary.Validation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories.BorrowOrderRepositories;

public class BOrderRepositoryWrite(LibraryContextWrite contextWrite) : IBOrderRepositoryWrite
{
    public async Task<int> AddOrder(BorrowOrderEntity order)
    {
        var book = await contextWrite.Books.Include(bookEntity => bookEntity.ActiveBorrowOrder)
            .FirstOrDefaultAsync(b => b.Id == order.BookId);

        if (book == null) { return 0; }
        if (book.ActiveBorrowOrder != null) { return -1; }

        var validator = new BOrderValidator();
        var result = await validator.ValidateAsync(order);
        if (!result.IsValid) { return -2; }

        book.BorrowOrders.Add(order);
        book.ActiveBorrowOrder = order;

        await contextWrite.SaveChangesAsync();
        return order.Id;
    }

    public async Task<int> RemoveOrder(int id)
    {
        var dbOrder = await contextWrite.Orders
            .FirstOrDefaultAsync(b => b.Id == id);

        if (dbOrder == null) return 0;

        contextWrite.Orders.Remove(dbOrder);
        await contextWrite.SaveChangesAsync();

        return 1;
    }

    public async Task<int> ReturnBook(int orderId)
    {
        var dbOrder = await contextWrite.Orders
            .FirstOrDefaultAsync(b => b.Id == orderId);

        if(dbOrder == null || dbOrder.IsActive == false) return 0;

        var dbBook = await contextWrite.Books
            .FirstOrDefaultAsync(b => b.Id == dbOrder.BookId);
        
        if(dbBook == null) return 0;

        dbOrder.IsActive = false;
        dbOrder.CloseDate = DateTime.Today;

        dbBook.ActiveBorrowOrder = null;
        await contextWrite.SaveChangesAsync();

        return orderId;
    }
}