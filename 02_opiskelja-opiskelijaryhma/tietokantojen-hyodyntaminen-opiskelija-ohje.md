# Opiskelija ja opiskelijaryhmä

Tutustu teoriaosioon, jossa neuvotaan miten saat hyödynnettyä MsSQL palvelinta Windows forms sovelluksessa. Voit käyttää myös MySQL-tietokantaa.
[Tietokanta ja c#](https://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C) 

Tehtävässä tehdään lomake -sovellus, jolla saa lisättyä nimen tietokannassa olevaan opiskelija tauluun. 
+ Visual Studio - new project - Windows forms app - Projektin ja tietokannan nimeksi 'T1' tai 'Opiskelijat'
+ Luodaan tietokanta ja siihen taulut nimeltä opiskelija ja opiskelijaryhma
+ Tauluihin luodaan tarvittavat kentät (opiskelijaan mm. id, nimi ja ryhmään id, tunnus)
```sql
CREATE TABLE opiskelija
(
    id INT PRIMARY KEY IDENTITY,
    etunimi NVARCHAR(50),
    sukunimi NVARCHAR(50),
    ryhma_id INT
)

CREATE TABLE opiskelijaryhma
(
    id INT PRIMARY KEY IDENTITY,
    ryhmannimi NVARCHAR(50)
)
```
+ WindowsForms-sovellus, jonka avulla lisätään, haetaan ja poistetaan tietoja tietokannasta.
+ Selvitä miten sovelluksen ja tietokannan välinen yhteys muodostetaan.
 
## Tehtävät 

Alla olevan ohjeen oletus on, että opiskelijoiden ja ryhmän suhde on monen suhde yhteen. Voit halutessasi toteuttaa myös tietokantaskeeman, jossa opiskelijoiden ja ryhman suhde on monen suhden moneen. Huomaa, että tällöin tarvitse yhden välitaulun lisää.

1. Luo tietokantaan opiskelija -taulu ja siihen kentät id, etunimi ja sukunimi. Lisää tietokantaan kymmenen opiskelijaa.
```sql
CREATE TABLE opiskelija
(
    id INT PRIMARY KEY IDENTITY,
    etunimi NVARCHAR(50),
    sukunimi NVARCHAR(50),
    ryhma_id INT
)

INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id) VALUES ('Matti', 'Meikäläinen', 1)
INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id) VALUES ('Roope', 'Ankka', 2)
INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id) VALUES ('Aku', 'Ankka', 3)
INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id) VALUES ('Hessu', 'Hopo', 3)
INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id) VALUES ('Mikki', 'Hiiri', 1)
INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id) VALUES ('Iines', 'Ankka', 1)
INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id) VALUES ('Hannu', 'Hanhi', 2)
INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id) VALUES ('Aapo', 'Kissa', 1)
INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id) VALUES ('Patrik', 'Tähti', 2)
INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id) VALUES ('Eemeli', 'Kettu', 3)

```
2. Luo tietokantaan opiskelijaryhma -taulu ja siihen kentät id ja ryhmannimi. Lisää tietokantaan ainakin kolme eri ryhmää.
```sql
CREATE TABLE opiskelijaryhma
(
    id INT PRIMARY KEY IDENTITY,
    ryhmannimi NVARCHAR(50)
)

INSERT INTO opiskelijaryhma (ryhmannimi) VALUES ('Ryhmä 1')
INSERT INTO opiskelijaryhma (ryhmannimi) VALUES ('Ryhmä 2')
INSERT INTO opiskelijaryhma (ryhmannimi) VALUES ('Ryhmä 3')
```

3. Lisää lomakkeelle DatagridView-komponentti, johon tulostat kaikki opiskelijoiden nimet. 

4. Lisää combobox, jolle haet kaikki tietokannan opiskelijaryhmät. 

5. Lisää nappi ja tarvittavat kentät, joiden avulla saat lisättyä uuden opiskelijan tietokantaan.

6. Muuta ohjelmaa, jotta opiskelija saadaan sidottua luomisen yhteydessä valittuun opiskelijaryhmään.
[Comboxin tietojen lisäys](https://www.c-sharpcorner.com/UploadFile/0f68f2/programmatically-binding-datasource-to-combobox-in-multiple/)

7. Lisää lomakkeelle toiminne, jolla saat poistettua valitun opiskelijan ohjelman näkymästä ja tietokantataulusta. 

Vihje! Kannattaa varmistaa, että olet perillä miten tiedot luetaan tietokannasta, jotta id, jonka otat valitsemallasi tavalla käyttöliittymässä vastaa tietokannassa olevaa id:tä.

Lisätietoa databindigistä voi lukea seuraavista artikkeleista:


https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqldataadapter?view=dotnet-plat-ext-7.0&viewFallbackFrom=net-7.0

https://learn.microsoft.com/en-us/dotnet/api/system.data.dataset?view=net-7.0

```c#
Vihje id:n hakemiseen datagridistä.

if (e.RowIndex >= 0)
    {
        int selectedId = int.Parse(studentGridView.Rows[e.RowIndex].Cells["id"].Value.ToString());
        
    }
```
