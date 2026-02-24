CREATE DATABASE vesuv;
USE vesuv;
CREATE TABLE Gast (
  GastID INT AUTO_INCREMENT PRIMARY KEY,
  Vorname VARCHAR(50),
  Nachname VARCHAR(50),
  Telefon VARCHAR(30)
);


CREATE TABLE Mitarbeiter (
	MitarbeiterID INT AUTO_INCREMENT PRIMARY KEY,
    Vorname varchar(20),
    Nachname varchar(20),
    Telefon varchar(11),
    passwort varchar(25),
    geburtsjahr varchar (4),
    benutzername varchar(44)
);


Insert into Mitarbeiter (Vorname, Nachname, passwort, Telefon,geburtsjahr, benutzername)
Values 
('Julian','Hillebrecht','530423','01234567890','2007','JHillebrecht2007'),
('Isa','Dagli','4002','01234567890','2004','IDagli2004');


CREATE TABLE Tisch (
  TischID INT AUTO_INCREMENT PRIMARY KEY,
  Plaetze INT,
  Lage VARCHAR(50),
  istBesetzt BOOLEAN DEFAULT 0,
  Slot INT
);

Create table TischName (
TischName varchar (15)
);


CREATE TABLE Speise (
  SpeiseID INT AUTO_INCREMENT PRIMARY KEY,
  Bezeichnung VARCHAR(100),
  Beschreibung VARCHAR(255),
  Preis DECIMAL(6,2),
  SpeiseType Varchar(25),
  Zutaten Varchar (100)
);


CREATE TABLE Reservierung (
  ReservierungID INT AUTO_INCREMENT PRIMARY KEY,
  Datum DATE,
  Slot INT,
  Personenanzahl INT,
  GastID INT,
  TischID INT,
  IsDeleted BOOLEAN DEFAULT 0,
  FOREIGN KEY (GastID) REFERENCES Gast(GastID),
  FOREIGN KEY (TischID) REFERENCES Tisch(TischID)
);


CREATE TABLE Bestellung (
  BestellungID INT AUTO_INCREMENT PRIMARY KEY,
  Zeitpunkt DATETIME,
  TischID INT,
  MitarbeiterID INT,
  Foreign key (GastID) REFERENCES Gast(GastID),
  FOREIGN KEY (TischID) REFERENCES Tisch(TischID),
  FOREIGN KEY (MitarbeiterID) REFERENCES Mitarbeiter(MitarbeiterID)
);


CREATE TABLE Bestellposition (
  BestellpositionID INT AUTO_INCREMENT PRIMARY KEY,
  BestellungID INT,
  SpeiseID INT,
  Menge INT,
  Einzelpreis DECIMAL(6,2),
  FOREIGN KEY (BestellungID) REFERENCES Bestellung(BestellungID),
  FOREIGN KEY (SpeiseID) REFERENCES Speise(SpeiseID)
);


INSERT INTO Speise (SpeisenID, Bezeichnung, Beschreibung, Preis, SpeiseType, Zutaten)
VALUES 
-- PIZZA
(1, 'Margherita', 'Pizza mit Tomaten und Mozzarella', 8.90, 'Hauptgericht', 'Tomaten, Mozzarella, Basilikum'),
(2, 'Salami', 'Pizza mit Tomatensauce, Mozzarella und Salami', 9.50, 'Hauptgericht', 'Tomaten, Mozzarella, Salami'),
(3, 'Prosciutto', 'Pizza mit Tomatensauce, Mozzarella und Kochschinken', 9.80, 'Hauptgericht', 'Tomaten, Mozzarella, Kochschinken'),
(4, 'Funghi', 'Pizza mit Tomatensauce, Mozzarella und Champignons', 9.20, 'Hauptgericht', 'Tomaten, Mozzarella, Champignons'),
(5, 'Hawaii', 'Pizza mit Schinken und Ananas', 10.00, 'Hauptgericht', 'Tomaten, Mozzarella, Schinken, Ananas'),
(6, 'Quattro Stagioni', 'Pizza mit vier verschiedenen Belägen', 11.50, 'Hauptgericht', 'Tomaten, Mozzarella, Schinken, Artischocken, Oliven, Champignons'),
(7, 'Quattro Formaggi', 'Pizza mit vier Käsesorten', 10.90, 'Hauptgericht', 'Mozzarella, Gorgonzola, Parmesan, Emmentaler'),
(8, 'Diavola', 'Scharfe Pizza mit Salami und Chili', 10.50, 'Hauptgericht', 'Tomaten, Mozzarella, scharfe Salami, Chili'),
-- Pasta
(9, 'Spaghetti Bolognese', 'Pasta mit Rinderhackfleisch-Tomatensauce', 11.50, 'Hauptgericht', 'Spaghetti, Rinderhackfleisch, Tomaten, Zwiebeln'),
(10, 'Spaghetti Carbonara', 'Pasta mit Ei, Käse und Speck', 12.00, 'Hauptgericht', 'Spaghetti, Ei, Pecorino, Speck'),
(11, 'Penne Arrabbiata', 'Pasta mit scharfer Tomatensauce', 10.50, 'Hauptgericht', 'Penne, Tomaten, Knoblauch, Chili'),
(12, 'Lasagne al Forno', 'Überbackene Lasagne mit Fleischragù', 13.50, 'Hauptgericht', 'Lasagneplatten, Rinderhackfleisch, Tomaten, Béchamelsauce'),
(13, 'Tagliatelle al Pesto', 'Bandnudeln mit Basilikum-Pesto', 11.00, 'Hauptgericht', 'Tagliatelle, Basilikum, Pinienkerne, Parmesan, Olivenöl')
