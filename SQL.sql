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
    benutzername varchar(44),
	IsDeleted BOOLEAN DEFAULT 0
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
  Zutaten Varchar (100),
  IsDeleted BOOLEAN DEFAULT 0
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
  GastID INT,
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


INSERT INTO Speise (Bezeichnung, Beschreibung, Preis, SpeiseType, Zutaten)
VALUES 
-- Speisen

-- PIZZA
('Margherita', 'Pizza mit Tomaten und Mozzarella', 8.90, 'Hauptgericht', 'Tomaten, Mozzarella, Basilikum'),
('Salami', 'Pizza mit Tomatensauce, Mozzarella und Salami', 9.50, 'Hauptgericht', 'Tomaten, Mozzarella, Salami'),
('Prosciutto', 'Pizza mit Tomatensauce, Mozzarella und Kochschinken', 9.80, 'Hauptgericht', 'Tomaten, Mozzarella, Kochschinken'),
('Funghi', 'Pizza mit Tomatensauce, Mozzarella und Champignons', 9.20, 'Hauptgericht', 'Tomaten, Mozzarella, Champignons'),
('Hawaii', 'Pizza mit Schinken und Ananas', 10.00, 'Hauptgericht', 'Tomaten, Mozzarella, Schinken, Ananas'),
('Quattro Stagioni', 'Pizza mit vier verschiedenen Belägen', 11.50, 'Hauptgericht', 'Tomaten, Mozzarella, Schinken, Artischocken, Oliven, Champignons'),
('Quattro Formaggi', 'Pizza mit vier Käsesorten', 10.90, 'Hauptgericht', 'Mozzarella, Gorgonzola, Parmesan, Emmentaler'),
('Diavola', 'Scharfe Pizza mit Salami und Chili', 10.50, 'Hauptgericht', 'Tomaten, Mozzarella, scharfe Salami, Chili'),
-- Pasta
('Spaghetti Bolognese', 'Pasta mit Rinderhackfleisch-Tomatensauce', 11.50, 'Hauptgericht', 'Spaghetti, Rinderhackfleisch, Tomaten, Zwiebeln'),
('Spaghetti Carbonara', 'Pasta mit Ei, Käse und Speck', 12.00, 'Hauptgericht', 'Spaghetti, Ei, Pecorino, Speck'),
('Penne Arrabbiata', 'Pasta mit scharfer Tomatensauce', 10.50, 'Hauptgericht', 'Penne, Tomaten, Knoblauch, Chili'),
('Lasagne al Forno', 'Überbackene Lasagne mit Fleischragù', 13.50, 'Hauptgericht', 'Lasagneplatten, Rinderhackfleisch, Tomaten, Béchamelsauce'),
('Tagliatelle al Pesto', 'Bandnudeln mit Basilikum-Pesto', 11.00, 'Hauptgericht', 'Tagliatelle, Basilikum, Pinienkerne, Parmesan, Olivenöl'),
-- Salat
('Caesar Salat', 'Römersalat mit Caesar-Dressing und Croutons', 9.50, 'Vorspeise', 'Römersalat, Croutons, Parmesan, Caesar-Dressing'),
('Griechischer Salat', 'Salat mit Feta und Oliven', 8.90, 'Vorspeise', 'Tomaten, Gurken, Feta, Oliven, Zwiebeln'),
('Gemischter Salat', 'Bunter Salat mit verschiedenen Blattsalaten', 7.50, 'Vorspeise', 'Blattsalat, Tomaten, Gurken, Karotten'),
('Thunfischsalat', 'Salat mit Thunfisch und Zwiebeln', 9.80, 'Vorspeise', 'Blattsalat, Thunfisch, Zwiebeln, Oliven'),
('Caprese', 'Tomaten mit Mozzarella und Basilikum', 8.50, 'Vorspeise', 'Tomaten, Mozzarella, Basilikum, Olivenöl'),
('Hähnchensalat', 'Salat mit gegrilltem Hähnchenbrustfilet', 10.90, 'Hauptgericht', 'Blattsalat, Hähnchenbrust, Tomaten, Gurken'),
('Rucolasalat', 'Rucola mit Parmesan und Kirschtomaten', 8.20, 'Vorspeise', 'Rucola, Parmesan, Kirschtomaten, Balsamico'),
-- Antipasti
('Bruschetta', 'Geröstetes Brot mit Tomaten und Basilikum', 6.50, 'Vorspeise', 'Baguette, Tomaten, Basilikum, Olivenöl, Knoblauch'),
('Vitello Tonnato', 'Kalbfleisch mit Thunfischsauce', 11.50, 'Vorspeise', 'Kalbfleisch, Thunfisch, Kapern, Mayonnaise'),
('Carpaccio', 'Hauchdünnes Rindfleisch mit Parmesan', 12.00, 'Vorspeise', 'Rinderfilet, Parmesan, Rucola, Olivenöl'),
('Antipasti Misti', 'Gemischte italienische Vorspeisenplatte', 13.50, 'Vorspeise', 'Gegrilltes Gemüse, Oliven, Salami, Käse'),
('Gegrillte Zucchini', 'Marinierte und gegrillte Zucchinischeiben', 7.20, 'Vorspeise', 'Zucchini, Olivenöl, Knoblauch, Kräuter'),
('Gegrillte Paprika', 'Marinierte Paprika mit Olivenöl', 7.20, 'Vorspeise', 'Paprika, Olivenöl, Knoblauch, Kräuter'),
('Olivenmix', 'Verschiedene marinierte Oliven', 5.50, 'Vorspeise', 'Grüne Oliven, Schwarze Oliven, Kräuter'),
('Mozzarella Sticks', 'Frittierte Mozzarellasticks mit Dip', 6.90, 'Vorspeise', 'Mozzarella, Paniermehl, Tomatendip'),
('Prosciutto e Melone', 'Parmaschinken mit Honigmelone', 9.80, 'Vorspeise', 'Parmaschinken, Honigmelone'),
('Focaccia', 'Italienisches Fladenbrot mit Rosmarin', 5.90, 'Vorspeise', 'Mehl, Hefe, Olivenöl, Rosmarin, Salz'),
-- Suppe
('Minestrone', 'Italienische Gemüsesuppe mit Pasta', 6.90, 'Vorspeise', 'Karotten, Zucchini, Sellerie, Tomaten, Pasta, Bohnen'),
('Tomatensuppe', 'Cremige Tomatensuppe mit Basilikum', 5.90, 'Vorspeise', 'Tomaten, Zwiebeln, Knoblauch, Sahne, Basilikum'),
('Zucchinisuppe', 'Feine Suppe aus frischer Zucchini', 6.50, 'Vorspeise', 'Zucchini, Zwiebeln, Kartoffeln, Gemüsebrühe'),
('Kartoffelsuppe', 'Herzhafte Suppe mit Kartoffeln und Gemüse', 6.50, 'Vorspeise', 'Kartoffeln, Karotten, Lauch, Sellerie, Sahne'),
('Hühnersuppe', 'Klassische Suppe mit Huhn und Gemüse', 7.50, 'Vorspeise', 'Hühnerfleisch, Karotten, Sellerie, Nudeln, Petersilie'),
('Gulaschsuppe', 'Würzige Rindfleischsuppe mit Paprika', 8.50, 'Vorspeise', 'Rindfleisch, Paprika, Zwiebeln, Kartoffeln, Paprikapulver'),

-- Getränke

-- Alkoholfrei
('Orangensaft', 'Frisch gepresster Orangensaft', 3.80, 'Getränk', 'Orangensaft'),
('Cola', 'Klassische Cola', 2.90, 'Getränk', 'Wasser, Zucker, Kohlensäure, Karamell, Aromen'),
('Fanta', 'Erfrischende Orangenlimonade', 2.90, 'Getränk', 'Wasser, Zucker, Kohlensäure, Orangenaroma'),
('Sprite', 'Zitronen-Limetten-Limonade', 2.90, 'Getränk', 'Wasser, Zucker, Kohlensäure, Zitronen- und Limettenaroma'),
('Mineralwasser', 'Sprudelndes Mineralwasser', 2.50, 'Getränk', 'Mineralwasser'),
('Stillwasser', 'Ohne Kohlensäure', 2.50, 'Getränk', 'Mineralwasser'),
('Eistee Pfirsich', 'Pfirsich-Eistee kalt serviert', 3.20, 'Getränk', 'Wasser, Tee, Zucker, Pfirsicharoma'),
('Eistee Zitrone', 'Zitronen-Eistee kalt serviert', 3.20, 'Getränk', 'Wasser, Tee, Zucker, Zitronenaroma'),
('Limonade Zitrone', 'Hausgemachte Zitronenlimonade', 3.00, 'Getränk', 'Wasser, Zitronensaft, Zucker'),
('Limonade Himbeere', 'Hausgemachte Himbeerlimonade', 3.20, 'Getränk', 'Wasser, Himbeersaft, Zucker'),
('Orangina', 'Orangensaftgetränk mit Fruchtstückchen', 3.50, 'Getränk', 'Orangensaft, Zucker, Kohlensäure'),
-- Alkoholische
('Bier', 'Klassisches Pils vom Fass', 4.50, 'Getränk', 'Wasser, Malz, Hopfen, Hefe'),
('Weißwein', 'Trockener Weißwein aus Italien', 5.50, 'Getränk', 'Weintrauben'),
('Rotwein', 'Trockener Rotwein aus Italien', 5.50, 'Getränk', 'Weintrauben'),
('Prosecco', 'Italienischer Schaumwein', 6.00, 'Getränk', 'Weintrauben, Kohlensäure'),
('Aperol Spritz', 'Aperol, Prosecco und Soda', 7.50, 'Getränk', 'Aperol, Prosecco, Soda, Orangenscheibe'),
('Campari Soda', 'Bitterer Campari mit Soda', 6.50, 'Getränk', 'Campari, Soda, Eis'),
('Hugo', 'Prosecco, Holunderblütensirup und Minze', 7.00, 'Getränk', 'Prosecco, Holunderblütensirup, Minze, Soda'),
('Gin Tonic', 'Gin mit Tonic Water', 8.00, 'Getränk', 'Gin, Tonic Water, Limette, Eiswürfel'),

-- Dessert
('Tiramisu', 'Italienisches Dessert mit Mascarpone und Kaffee', 6.50, 'Dessert', 'Mascarpone, Kaffee, Löffelbiskuit, Zucker, Eier, Kakao'),
('Panna Cotta', 'Cremige Vanille-Pudding-Spezialität', 5.90, 'Dessert', 'Sahne, Zucker, Vanille, Gelatine, Beeren'),
('Gelato', 'Italienisches Speiseeis', 4.50, 'Dessert', 'Milch, Zucker, Eigelb, Vanille, Fruchtaromen'),
('Profiteroles', 'Brandteigkugeln gefüllt mit Sahne und Schokolade', 6.80, 'Dessert', 'Brandteig, Sahne, Schokolade'),
('Creme Brûlée', 'Karamellisierte Vanillecreme', 6.90, 'Dessert', 'Sahne, Zucker, Eigelb, Vanille'),
('Obstsalat', 'Frischer Obstsalat der Saison', 5.50, 'Dessert', 'Äpfel, Birnen, Trauben, Kiwi, Orange, Honig');
