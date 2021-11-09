# Identity-Server


# Getting started

Run Identity Server 4

```
docker compose up -d --build
```



# EF Core


```
Add-Migration InitialCreate -Context PersistedGrantDbContext -Output Migrations/PersistedGrantDb

Add-Migration InitialCreate -Context ConfigurationDbContext -Output Migrations/ConfigurationDb
```
