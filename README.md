# Dealeron - Sales Taxes - Backend Developer.

This is a console application for Coding Test.

## Problem: Sales Taxes

There are a variety of items for sale at a store. When a customer purchases items, they receive a receipt. The receipt 
lists all of the items purchased, the sales price of each item (with taxes included), the total sales taxes for all items, 
and the total sales price. 

Basic sales tax applies to all items at a rate of 10% of the item’s list price, with the exception of books, food, and 
medical products, which are exempt from basic sales tax. An import duty (import tax) applies to all imported items at 
a rate of 5% of the shelf price, with no exceptions. 

Write an application that takes input for shopping baskets and returns receipts in the format shown below, calculating 
all taxes and totals correctly. When calculating the sales tax, round the value up to the nearest 5 cents. For example, if 
a taxable item costs $5.60, an exact 10% tax would be $0.56, and the final price after adding the rounded tax of $0.60 
should be $6.20. 

## Development Process

For solving this I thought of creating a structure based on Domain Driven Design. Using the SOLID principles, I segregated each Service following the Single Responsability Principle.

## Architecture

The application was divided in:
    - Console
        - The Console project is the actual console application.
    - Core
        - The Core project is where things actually happens. All Services are in this one.
    - Domain
        - The Domain project would host all Data structure, in the case I'm just using it to host models.
    - Tests
        - This Tests project is where all tests are done.

The application is pretty straightforward without any unecessary stuff.

## Technologies

*   .Net 6