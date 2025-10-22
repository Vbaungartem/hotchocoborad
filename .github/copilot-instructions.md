# Project Overview

Este projeto é uma API.NET 9 que segue rigorosamente os princípios de Domain-Driven Design (DDD) e Command Query
Responsibility Segregation (CQRS). O protocolo de comunicação é ministrado via GraphQL, utilizando a lib HotChocolate.
A lógica de negócios é encapsulada em Entidades e manipulada através de Commands e
Queries, orquestrados pela biblioteca MediatR. A persistência de dados é gerenciada pelo Entity Framework Core.

**O princípio mais importante é a consistência. TODO o código novo deve seguir os padrões existentes.**

**Todo o código deve ser escrito em inglês, exceto comentários e documentação.**

# O Blueprint Canônico"

Será distposto nessas instruções o passo a passo para a criação de uma entidade completa.

Vamos levar em consideração que a nova entidade a ser criada se chama `Invoice`.

Uma nova entidade no projeto envolve a criação de um diretório específico para ela e seus respectivos arquivos, seguindo
padrões rigorosos de nomenclatura e estrutura.

No projeto `VB.HotChocoBoard.Domain` deverá ser criado um diretório com o nome da entidade no plural (ex: `Invoices`).

Dentro do diretório da entidade, deverão ser criados subdiretórios para:
- Entidades (Entities): Contém a entidade propriamente dita.
- Repositórios (Repositories): Contém a interface do repositório.
- Especificações (Specifications): Contém classes estáticas com métodos para filtrar consultas.
- Enums: Contém enums relacionados à entidade.

A entidade deve ser uma classe que encapsula a lógica de negócios e validações. Deve possuir um construtor que
inicializa suas propriedades e métodos para manipular seu estado. Ex:

```c#
public class Invoice
{
    Invoice()
    { }
    
    public Invoice(string number, DateTime issueDate, decimal total)
    {
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Invoice number cannot be empty.", nameof(number));
        
        if (total <= 0)
            throw new ArgumentException("Total must be greater than zero.", nameof(total));
        
        Number = number;
        
        IssueDate = issueDate;
        
        Total = total;
        
        IsCanceled = false;
    }
    
    public int Id { get; private set; }
    public string Number { get; private set; }
    public DateTime IssueDate { get; private set; }
    public decimal Total { get; private set; }
    public bool IsCanceled { get; private set; }
    
    public void UpdateTotalValue(decimal newValue)
    {
        if (newValue <= 0)
            throw new ArgumentException("The value must be greater than 0.", nameof(novoValor));
        Total = newValue;
    }
    
    public void Cancel()
    {
        IsCanceled = true;
    }
    
```

Sempre que uma entidade tiver um relacionamento com outra entidade, utilize o padrão de agregação do DDD. 
A entidade raiz deve ser a única que pode ser manipulada diretamente, e as entidades filhas devem ser manipuladas através da entidade raiz.
Devido a incompatibilidade do Hot Chocolate com Backing Fields, as coleções de entidades filhas devem ser inicializadas no construtor da entidade raiz.

Exemplo:

```c#
public class Order
{
    Order()
    { }
    
    public Order(int customerId)
    {
        CustomerId = customerId;
        OrderItems = new List<OrderItem>();
        Status = OrderStatus.Pending;
    }
    public int Id { get; private set; }
    public int CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }
    public List<OrderItem> OrderItems { get; private set; }
    public void AddItem(int productId, int quantity, decimal price)
    {
        var item = new OrderItem(productId, quantity, price);
        OrderItems.Add(item);
    }
    public void RemoveItem(int productId)
    {
        var item = OrderItems.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            OrderItems.Remove(item);
        }
    }
    public void Confirm()
    {
        if (!OrderItems.Any())
            throw new InvalidOperationException("Cannot confirm an order with no items.");
        Status = OrderStatus.Confirmed;
    }
}
public class OrderItem
{
    OrderItem()
    { }
    
    public OrderItem(int productId, int quantity, decimal price)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.", nameof(price));
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
    
    public int Id { get; private set; }
    
    public int ProductId { get; private set; }
    
    public int Quantity { get; private set; }
    
    public decimal Price { get; private set; }
}
```
    
