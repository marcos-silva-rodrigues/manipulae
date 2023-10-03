# Manipulae Challenge

# Sobre

Mini api que gera uma base de dados com 50 registros de videos sobre manipulação de medicamentos usando a api do youtube

## Features

- [x] Listar os videos já cadastrados 
- [x] Listar videos com  filtros pela data de publicação
- [x] Listar videos filtrados por titulo ou descrição ou autor(Nome do canal) 
- [x] Buscar por um video especifico pelo id 
- [x] Cadastrar novos videos
- [x] Atualizar um video ja cadastrado 
- [x] Marca um video como excluido na base 

## Variáveis

Insira sua api key do google e o caminho para o arquivo do sqlite no appsettings.json

```json
{
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "SqlitePath": "Data Source=<Escolha um caminho aqui/>"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ApiKey": "<Sua ApiKey Aqui/>"
}
```

## Rodando o projeto com docker

```bash
# Crie a imagem
docker build -t mani-api .

# Rodando o container
docker run --name mani-api -p "8000:80" mani-api
```
