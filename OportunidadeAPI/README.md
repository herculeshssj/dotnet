Oportunidade API
================

Rodando no Docker

Build:

```
docker build -t oportunidadeapi .
```

Executando o container:

```
docker run -d -p 7242:80 --name oportunidade-api oportunidadeapi
```