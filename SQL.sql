CREATE DATABASE vesuv;
USE vesuv;


-- =========================
-- GAST
-- =========================
CREATE TABLE Gast (
  GastID INT AUTO_INCREMENT PRIMARY KEY,
  Vorname VARCHAR(50) NOT NULL,
  Nachname VARCHAR(50) NOT NULL,
  Telefon VARCHAR(30) NOT NULL,
  IsDeleted BOOLEAN DEFAULT 0
);

-- =========================
-- MITARBEITER
-- =========================
CREATE TABLE Mitarbeiter (
  MitarbeiterID INT AUTO_INCREMENT PRIMARY KEY,
  Vorname VARCHAR(20) NOT NULL,
  Nachname VARCHAR(20) NOT NULL,
  Telefon VARCHAR(20),
  passwort_hash VARCHAR(255) NOT NULL,
  geburtsjahr YEAR,
  bereich VARCHAR(25),
  IsDeleted BOOLEAN DEFAULT 0
);

-- =========================
-- TISCH
-- =========================
CREATE TABLE Tisch (
  TischID INT AUTO_INCREMENT PRIMARY KEY,
  TischName VARCHAR(15) NOT NULL UNIQUE,
  Plaetze INT NOT NULL,
  Lage VARCHAR(50),
  istBesetzt BOOLEAN DEFAULT 0, 
  Slot INT DEFAULT 0,
  KellnerID INT NOT NULL,
  FOREIGN KEY (KellnerID) REFERENCES Mitarbeiter(MitarbeiterID)
);

-- =========================
-- SPEISE
-- =========================
CREATE TABLE Speise (
  SpeiseID INT AUTO_INCREMENT PRIMARY KEY,
  Bezeichnung VARCHAR(100) NOT NULL,
  Beschreibung VARCHAR(255),
  Preis DECIMAL(6,2) NOT NULL,
  SpeiseType VARCHAR(25),
  Kategorie varchar(25),
  Zutaten VARCHAR(100),
  IsDeleted BOOLEAN DEFAULT 0
);

-- =========================
-- RESERVIERUNG
-- =========================
CREATE TABLE Reservierung (
  ReservierungID INT AUTO_INCREMENT PRIMARY KEY,
  TischID INT NOT NULL,
  Slot INT NOT NULL,
  GastID INT NOT NULL,
  Datum DATE NOT NULL,
  Uhrzeit TIME NOT NULL,
  Personenanzahl INT NOT NULL,
  IsDeleted BOOLEAN DEFAULT 0,

  FOREIGN KEY (GastID) REFERENCES Gast(GastID),
  FOREIGN KEY (TischID) REFERENCES Tisch(TischID)
);	

SELECT TischID, TischName FROM Tisch;


-- =========================
-- BESTELLUNG (Kopf)
-- =========================
CREATE TABLE Bestellung (
  BestellungID INT AUTO_INCREMENT PRIMARY KEY,
  Zeitpunkt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  TischID INT NOT NULL,
  MitarbeiterID INT NOT NULL,
  GastID INT NOT NULL,

  FOREIGN KEY (TischID) REFERENCES Tisch(TischID),
  FOREIGN KEY (MitarbeiterID) REFERENCES Mitarbeiter(MitarbeiterID),
  FOREIGN KEY (GastID) REFERENCES Gast(GastID)
);

Select * from Bestellung;

INSERT INTO Gast (Vorname, Nachname, Telefon) 
VALUES ('Laufkundschaft', 'Allgemein', '0000');

SELECT * FROM Gast;

-- =========================
-- BESTELLPOSITION (Positionen)
-- =========================
CREATE TABLE Bestellposition (
  BestellpositionID INT AUTO_INCREMENT PRIMARY KEY,
  BestellungID INT NOT NULL,
  SpeiseID INT NOT NULL,
  Menge INT NOT NULL DEFAULT 1,
  Einzelpreis DECIMAL(6,2) NOT NULL,

  FOREIGN KEY (BestellungID) REFERENCES Bestellung(BestellungID),
  FOREIGN KEY (SpeiseID) REFERENCES Speise(SpeiseID)
);

SELECT 
    B.BestellungID AS 'Nr', 
    DATE_FORMAT(B.Zeitpunkt, '%H:%i') AS 'Uhrzeit', 
    T.TischName AS 'Tisch', 
    SUM(BP.Menge * BP.Einzelpreis) AS 'Summe'
FROM Bestellung B
JOIN Tisch T ON B.TischID = T.TischID
JOIN Bestellposition BP ON B.BestellungID = BP.BestellungID
WHERE DATE(B.Zeitpunkt) = CURDATE()
GROUP BY B.BestellungID, B.Zeitpunkt, T.TischName 
ORDER BY B.Zeitpunkt DESC;

INSERT INTO Mitarbeiter (Vorname ,Nachname,Telefon,passwort_hash,geburtsjahr, bereich)
VALUES
-- Manager
('Julian','Hillebrecht','01234567890','530423','2007','Manager'),
('Isa','Dagli','01234567890','4002','2004','Manager'),
-- Köche
('Max', 'Mustermann', '01234567890', 'Max718', 1985,'Koch'),
('Anna', 'Schmidt', '09876543210', 'Anna812', 1990,'Koch'),
('Tom', 'Becker', '01555123456', 'Tom123', 1982,'Koch'),
('Laura', 'Fischer', '01777654321', 'Laura781', 1995,'Koch'),
-- Kellner
('Sophie', 'Neumann', '01666111222', 'Sophie123', 1988,'Kellner'),
('Lukas', 'Keller', '01666333444', 'Lukas456', 1991,'Kellner'),
('Julia', 'Hoffmann', '01666555666', 'Julia789', 1983,'Kellner'),
('Fabian', 'Wolf', '01666777888', 'Fabian321', 1987,'Kellner'),
('Nina', 'Richter', '01666999000', 'Nina654', 1992,'Kellner');

	
Select * from Speise;

INSERT INTO Tisch (TischName, Plaetze, Lage, KellnerID)
VALUES
('Tisch1',2,'Fenster',7),
('Tisch2',2,'Fenster',7),
('Tisch3',2,'Fenster',7),
('Tisch4',2,'Fenster',7),
('Tisch5',2,'Fenster',7),
('Tisch6',2,'Innenraum',7),
('Tisch7',2,'Innenraum',7),
('Tisch8',2,'Fenster',7),
('Tisch9',4,'Innenraum',8),
('Tisch10',4,'Innenraum',8),
('Tisch11',4,'Innenraum',8),
('Tisch12',4,'Innenraum',8),
('Tisch13',4,'Innenraum',8),
('Tisch14',4,'Innenraum',8),
('Tisch15',4,'Innenraum',8),
('Tisch16',4,'Innenraum',8),
('Tisch17',4,'Innenraum',9),
('Tisch18',4,'Innenraum',9),
('Tisch19',4,'Innenraum',9),
('Tisch20',4,'Innenraum',9),
('Tisch21',4,'Innenraum',9),
('Tisch22',4,'Innenraum',9),
('Tisch23',4,'Innenraum',9),
('Tisch24',4,'Innenraum',9),
('Tisch25',10,'Fenster',10),
('Tisch26',10,'Fenster',10),
('Tisch27',10,'Fenster',10),
('Tisch28',10,'Fenster',10),
('Tisch29',4,'Fenster',10),
('Tisch30',4,'Fenster',10),
('Tisch31',4,'Fenster',10),
('Tisch32',4,'Fenster',10),
('Tisch33',8,'Fenster',11),
('Tisch34',8,'Fenster',11),
('Tisch35',8,'Fenster',11),
('Tisch36',8,'Innenraum',11),
('Tisch37',8,'Fenster',11),
('Tisch38',8,'Innenraum',11),
('Tisch39',8,'Fenster',11),
('Tisch40',8,'Fenster',11);


INSERT INTO Speise (Bezeichnung, Beschreibung, Preis, SpeiseType, Kategorie, Zutaten)
VALUES 
-- Speisen

-- PIZZA
('Margherita', 'Pizza mit Tomaten und Mozzarella', 8.90, 'Hauptgericht','Pizza', 'Tomaten, Mozzarella, Basilikum'),
('Salami', 'Pizza mit Tomatensauce, Mozzarella und Salami', 9.50, 'Hauptgericht','Pizza', 'Tomaten, Mozzarella, Salami'),
('Prosciutto', 'Pizza mit Tomatensauce, Mozzarella und Kochschinken', 9.80, 'Hauptgericht','Pizza', 'Tomaten, Mozzarella, Kochschinken'),
('Funghi', 'Pizza mit Tomatensauce, Mozzarella und Champignons', 9.20, 'Hauptgericht','Pizza', 'Tomaten, Mozzarella, Champignons'),
('Hawaii', 'Pizza mit Schinken und Ananas', 10.00, 'Hauptgericht','Pizza', 'Tomaten, Mozzarella, Schinken, Ananas'),
('Quattro Stagioni', 'Pizza mit vier verschiedenen Belägen', 11.50, 'Hauptgericht','Pizza', 'Tomaten, Mozzarella, Schinken, Artischocken, Oliven, Champignons'),
('Quattro Formaggi', 'Pizza mit vier Käsesorten', 10.90, 'Hauptgericht','Pizza', 'Mozzarella, Gorgonzola, Parmesan, Emmentaler'),
('Diavola', 'Scharfe Pizza mit Salami und Chili', 10.50, 'Hauptgericht','Pizza', 'Tomaten, Mozzarella, scharfe Salami, Chili'),
-- Pasta
('Spaghetti Bolognese', 'Pasta mit Rinderhackfleisch-Tomatensauce', 11.50, 'Hauptgericht','Pasta', 'Spaghetti, Rinderhackfleisch, Tomaten, Zwiebeln'),
('Spaghetti Carbonara', 'Pasta mit Ei, Käse und Speck', 12.00, 'Hauptgericht','Pasta', 'Spaghetti, Ei, Pecorino, Speck'),
('Penne Arrabbiata', 'Pasta mit scharfer Tomatensauce', 10.50, 'Hauptgericht','Pasta', 'Penne, Tomaten, Knoblauch, Chili'),
('Lasagne al Forno', 'Überbackene Lasagne mit Fleischragù', 13.50, 'Hauptgericht','Pasta', 'Lasagneplatten, Rinderhackfleisch, Tomaten, Béchamelsauce'),
('Tagliatelle al Pesto', 'Bandnudeln mit Basilikum-Pesto', 11.00, 'Hauptgericht','Pasta', 'Tagliatelle, Basilikum, Pinienkerne, Parmesan, Olivenöl'),
-- Salat
('Caesar Salat', 'Römersalat mit Caesar-Dressing und Croutons', 9.50, 'Vorspeise','Salat', 'Römersalat, Croutons, Parmesan, Caesar-Dressing'),
('Griechischer Salat', 'Salat mit Feta und Oliven', 8.90, 'Vorspeise','Salat', 'Tomaten, Gurken, Feta, Oliven, Zwiebeln'),
('Gemischter Salat', 'Bunter Salat mit verschiedenen Blattsalaten', 7.50, 'Vorspeise','Salat', 'Blattsalat, Tomaten, Gurken, Karotten'),
('Thunfischsalat', 'Salat mit Thunfisch und Zwiebeln', 9.80, 'Vorspeise','Salat', 'Blattsalat, Thunfisch, Zwiebeln, Oliven'),
('Caprese', 'Tomaten mit Mozzarella und Basilikum', 8.50, 'Vorspeise','Salat', 'Tomaten, Mozzarella, Basilikum, Olivenöl'),
('Hähnchensalat', 'Salat mit gegrilltem Hähnchenbrustfilet', 10.90, 'Hauptgericht','Salat', 'Blattsalat, Hähnchenbrust, Tomaten, Gurken'),
('Rucolasalat', 'Rucola mit Parmesan und Kirschtomaten', 8.20, 'Vorspeise','Salat', 'Rucola, Parmesan, Kirschtomaten, Balsamico'),
-- Antipasti
('Bruschetta', 'Geröstetes Brot mit Tomaten und Basilikum', 6.50, 'Vorspeise','Antipasti', 'Baguette, Tomaten, Basilikum, Olivenöl, Knoblauch'),
('Vitello Tonnato', 'Kalbfleisch mit Thunfischsauce', 11.50, 'Vorspeise','Antipasti', 'Kalbfleisch, Thunfisch, Kapern, Mayonnaise'),
('Carpaccio', 'Hauchdünnes Rindfleisch mit Parmesan', 12.00, 'Vorspeise','Antipasti', 'Rinderfilet, Parmesan, Rucola, Olivenöl'),
('Antipasti Misti', 'Gemischte italienische Vorspeisenplatte', 13.50, 'Vorspeise','Antipasti', 'Gegrilltes Gemüse, Oliven, Salami, Käse'),
('Gegrillte Zucchini', 'Marinierte und gegrillte Zucchinischeiben', 7.20, 'Vorspeise','Antipasti', 'Zucchini, Olivenöl, Knoblauch, Kräuter'),
('Gegrillte Paprika', 'Marinierte Paprika mit Olivenöl', 7.20, 'Vorspeise','Antipasti', 'Paprika, Olivenöl, Knoblauch, Kräuter'),
-- Suppe
('Minestrone', 'Italienische Gemüsesuppe mit Pasta', 6.90, 'Vorspeise','Suppe', 'Karotten, Zucchini, Sellerie, Tomaten, Pasta, Bohnen'),
('Tomatensuppe', 'Cremige Tomatensuppe mit Basilikum', 5.90, 'Vorspeise','Suppe', 'Tomaten, Zwiebeln, Knoblauch, Sahne, Basilikum'),
('Zucchinisuppe', 'Feine Suppe aus frischer Zucchini', 6.50, 'Vorspeise','Suppe', 'Zucchini, Zwiebeln, Kartoffeln, Gemüsebrühe'),
('Kartoffelsuppe', 'Herzhafte Suppe mit Kartoffeln und Gemüse', 6.50, 'Vorspeise','Suppe', 'Kartoffeln, Karotten, Lauch, Sellerie, Sahne'),
('Hühnersuppe', 'Klassische Suppe mit Huhn und Gemüse', 7.50, 'Vorspeise','Suppe', 'Hühnerfleisch, Karotten, Sellerie, Nudeln, Petersilie'),
('Gulaschsuppe', 'Würzige Rindfleischsuppe mit Paprika', 8.50, 'Vorspeise','Suppe', 'Rindfleisch, Paprika, Zwiebeln, Kartoffeln, Paprikapulver'),

-- Getränke

-- Alkoholfrei
('Orangensaft', 'Frisch gepresster Orangensaft', 3.80, 'Getränk','Alkoholfrei', 'Orangensaft'),
('Cola', 'Klassische Cola', 2.90, 'Getränk','Alkoholfrei', 'Wasser, Zucker, Kohlensäure, Karamell, Aromen'),
('Fanta', 'Erfrischende Orangenlimonade', 2.90, 'Getränk','Alkoholfrei', 'Wasser, Zucker, Kohlensäure, Orangenaroma'),
('Sprite', 'Zitronen-Limetten-Limonade', 2.90, 'Getränk','Alkoholfrei', 'Wasser, Zucker, Kohlensäure, Zitronen- und Limettenaroma'),
('Mineralwasser', 'Sprudelndes Mineralwasser', 2.50, 'Getränk','Alkoholfrei', 'Mineralwasser'),
('Stillwasser', 'Ohne Kohlensäure', 2.50, 'Getränk','Alkoholfrei', 'Mineralwasser'),
('Eistee Pfirsich', 'Pfirsich-Eistee kalt serviert', 3.20, 'Getränk','Alkoholfrei', 'Wasser, Tee, Zucker, Pfirsicharoma'),
('Eistee Zitrone', 'Zitronen-Eistee kalt serviert', 3.20, 'Getränk','Alkoholfrei', 'Wasser, Tee, Zucker, Zitronenaroma'),
('Limonade Zitrone', 'Hausgemachte Zitronenlimonade', 3.00, 'Getränk','Alkoholfrei', 'Wasser, Zitronensaft, Zucker'),
('Limonade Himbeere', 'Hausgemachte Himbeerlimonade', 3.20, 'Getränk','Alkoholfrei', 'Wasser, Himbeersaft, Zucker'),
-- Alkoholische
('Bier', 'Klassisches Pils vom Fass', 4.50, 'Getränk','Alkoholische', 'Wasser, Malz, Hopfen, Hefe'),
('Weißwein', 'Trockener Weißwein aus Italien', 5.50, 'Getränk','Alkoholische', 'Weintrauben'),
('Rotwein', 'Trockener Rotwein aus Italien', 5.50, 'Getränk','Alkoholische', 'Weintrauben'),
('Prosecco', 'Italienischer Schaumwein', 6.00, 'Getränk','Alkoholische', 'Weintrauben, Kohlensäure'),
('Aperol Spritz', 'Aperol, Prosecco und Soda', 7.50, 'Getränk','Alkoholische', 'Aperol, Prosecco, Soda, Orangenscheibe'),
('Campari Soda', 'Bitterer Campari mit Soda', 6.50, 'Getränk','Alkoholische', 'Campari, Soda, Eis'),
('Hugo', 'Prosecco, Holunderblütensirup und Minze', 7.00, 'Getränk','Alkoholische', 'Prosecco, Holunderblütensirup, Minze, Soda'),
('Gin Tonic', 'Gin mit Tonic Water', 8.00, 'Getränk','Alkoholische', 'Gin, Tonic Water, Limette, Eiswürfel'),

-- Dessert
('Tiramisu', 'Italienisches Dessert mit Mascarpone und Kaffee', 6.50, 'Dessert','Dessert', 'Mascarpone, Kaffee, Löffelbiskuit, Zucker, Eier, Kakao'),
('Panna Cotta', 'Cremige Vanille-Pudding-Spezialität', 5.90, 'Dessert','Dessert', 'Sahne, Zucker, Vanille, Gelatine, Beeren'),
('Gelato', 'Italienisches Speiseeis', 4.50, 'Dessert','Dessert', 'Milch, Zucker, Eigelb, Vanille, Fruchtaromen'),
('Profiteroles', 'Brandteigkugeln gefüllt mit Sahne und Schokolade', 6.80,'Dessert', 'Dessert', 'Brandteig, Sahne, Schokolade'),
('Creme Brûlée', 'Karamellisierte Vanillecreme', 6.90, 'Dessert','Dessert', 'Sahne, Zucker, Eigelb, Vanille'),
('Obstsalat', 'Frischer Obstsalat der Saison', 5.50, 'Dessert','Dessert', 'Äpfel, Birnen, Trauben, Kiwi, Orange, Honig');


-- Umsatz Tag
SELECT SUM(Bestellposition.Menge * Bestellposition.Einzelpreis) AS TagesUmsatz
FROM Bestellung
JOIN Bestellposition ON Bestellung.BestellungID = Bestellposition.BestellungID
WHERE DATE(Bestellung.Zeitpunkt) = CURDATE();


-- Umsatz Woche
SELECT SUM(Bestellposition.Menge * Bestellposition.Einzelpreis) AS WochenUmsatz
FROM Bestellung
JOIN Bestellposition ON Bestellung.BestellungID = Bestellposition.BestellungID
WHERE YEARWEEK(Bestellung.Zeitpunkt, 1) = YEARWEEK(CURDATE(), 1);


-- Umsatz Monat
SELECT SUM(Bestellposition.Menge * Bestellposition.Einzelpreis) AS MonatsUmsatz
FROM Bestellung
JOIN Bestellposition ON Bestellung.BestellungID = Bestellposition.BestellungID
WHERE YEAR(Bestellung.Zeitpunkt) = YEAR(CURDATE())
AND MONTH(Bestellung.Zeitpunkt) = MONTH(CURDATE());
  
  
-- Umsatz Jahr  
SELECT SUM(Bestellposition.Menge * Bestellposition.Einzelpreis) AS JahresUmsatz
FROM Bestellung
JOIN Bestellposition ON Bestellung.BestellungID = Bestellposition.BestellungID
WHERE YEAR(Bestellung.Zeitpunkt) = YEAR(CURDATE());


-- Umsatz Insgesant
SELECT SUM(Bestellposition.Menge * Bestellposition.Einzelpreis) AS GesamtUmsatz
FROM Bestellung
JOIN Bestellposition ON Bestellung.BestellungID = Bestellposition.BestellungID;


-- Umsatz Kellner
SELECT 
    M.Vorname, 
    M.Nachname, 
    SUM(BP.Menge * BP.Einzelpreis) AS 'Umsatz'
FROM Mitarbeiter M
-- Wir verknüpfen den Mitarbeiter über die KellnerID des Tisches
JOIN Tisch T ON M.MitarbeiterID = T.KellnerID
-- Dann verknüpfen wir die Bestellungen, die an diesem Tisch gemacht wurden
JOIN Bestellung B ON T.TischID = B.TischID
JOIN Bestellposition BP ON B.BestellungID = BP.BestellungID
GROUP BY M.MitarbeiterID, M.Vorname, M.Nachname
ORDER BY Umsatz DESC;
