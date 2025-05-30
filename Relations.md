# Relations

## Table Relationships: Many-to-Many (Products <--> Categories)

```
Relations
Products ----- ProductsCategories ----- Categories
|     Id <----- ProductId (ForeignKey)           |
|              CategoryId (ForeignKey) -----> Id |
|________________________________________________|
                [many to many]
```
