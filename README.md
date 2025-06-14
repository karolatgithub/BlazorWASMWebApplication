# BlazorWASMWebApplication

## Aplikacja webowa Single Page Application uzywajaca uslug Rest do zarzadzania lista kontaktoow. Aby wejsc w edycje kontaktu, nalezy sie zalogowac. Tryb edycji mozliwy w ciagu 10 minut, po tym czasie trzeba sie ponownie zalogowac.

## Haslo logowania jest przesylane po sieci w tokenie waznym przez +/-10 sekund

## Tworzenie projektu bedac w katalogu work

```
dotnet new blazorwasm --hosted -o BlazorWASMWebApplication
```

## Utworzenie bazy danych Postgresql
### Baze danych Postgresql nalezy uruchomić na porcie 5432 na lokalnej maszynie

```
SET SEARCH_PATH TO public;
CREATE TABLE "Category" (
    "Id" INTEGER NOT NULL GENERATED BY DEFAULT AS IDENTITY
      ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" VARCHAR NOT NULL,
    CONSTRAINT "CategoryPk" PRIMARY KEY ("Id"),
    CONSTRAINT "CategoryNameUnique" UNIQUE ("Name")
);
CREATE TABLE "SubCategory" (
    "CategoryId" INTEGER NOT NULL,
    "Name" VARCHAR NOT NULL,
    CONSTRAINT "SubCategoryPk" PRIMARY KEY ("CategoryId", "Name"),
    CONSTRAINT "SubCategoryCategoryIdFkey"
      FOREIGN KEY ("CategoryId")
        REFERENCES "Category" ("Id") ON UPDATE NO ACTION ON DELETE NO ACTION
);
CREATE TABLE "Contact" (
    "Id" INTEGER NOT NULL GENERATED BY DEFAULT AS IDENTITY
      ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" VARCHAR NOT NULL,
    "Surname" VARCHAR NOT NULL,
    "Email" VARCHAR NOT NULL,
    "Password" VARCHAR NOT NULL,
    "Phone" VARCHAR NOT NULL,
    "BirthDate" DATE NOT NULL DEFAULT NOW(),
    "CategoryId" INTEGER,
    "SubCategory" VARCHAR,
    CONSTRAINT "ContactPk" PRIMARY KEY ("Id"),
    CONSTRAINT "ContactEmailUnique" UNIQUE ("Email"),
    CONSTRAINT "ContactCategoryIdFkey"
      FOREIGN KEY ("CategoryId")
        REFERENCES "Category" ("Id") ON UPDATE NO ACTION ON DELETE NO ACTION
);
```

```
INSERT INTO "Contact"
VALUES(1,'Karol','Kowalczyk','karol@wp.pl','QWxhITEyMzQx','123123123','1970-01-01',1,'Służbowy');
INSERT INTO "Category"
VALUES(1,'Służbowy');
INSERT INTO "Category"
VALUES(2,'Prywatny');
INSERT INTO "Category"
VALUES(3,'Inny');
INSERT INTO "SubCategory"
VALUES(1,'Klient');
INSERT INTO "SubCategory"
VALUES(1,'Nieokreślony');
INSERT INTO "SubCategory"
VALUES(1,'Szef');
```

```
SELECT setval('"Contact_Id_seq"', (SELECT MAX("Id") FROM "Contact"));
SELECT setval('"Category_Id_seq"', (SELECT MAX("Id") FROM "Category"));
```

## Testowanie

### Nalezy przejsc do katalogu BlazorWASMWebApplication/RESTApi i uruchomic serwer Api Rest z dostepem do danych za pomoca polecenia:

```
dotnet run
```

### Nastepnie mozna uruchomic aplikacje webowa BlazorWASMWebApplication.Client w Visual Studio klawiszem F5 o ile domyslna jest aplikacja jest BlazorWASMWebApplication.Client lub uruchomic z linii polecen bedac w katalogu BlazorWASMWebApplication/Client:

```
dotnet run
```

### Gdy w konsoli wyswietli sie na jakim porcie dziala aplikacja:

```
...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5059
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: *****\BlazorWASMWebApplication\Client
```

### Nalezy w przegladarce wkleic url:

```
http://localhost:5059
```

### ... i powinna wyswietlic sie strona startowa aplikacji

## Masowe hashowanie jawnych hasel w bazie danych kontaktow
### Nalezy w przegladarce wywolac url:

```
http://localhost:8888/api/contacts/hash_passwords
```
