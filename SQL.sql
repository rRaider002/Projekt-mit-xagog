CREATE DATABASE vesuv;
USE vesuv;
CREATE TABLE Gast (
  GastID INT AUTO_INCREMENT PRIMARY KEY,
  Vorname VARCHAR(50),
  Nachname VARCHAR(50),
  Telefon VARCHAR(30),
  IsDeleted BOOLEAN DEFAULT 0
);
CREATE TABLE Mitarbeiter (
	MitarbeiterID INT AUTO_INCREMENT PRIMARY KEY,
    Vorname varchar(50),
    Nachname varchar(50),
    Telefon varchar(50),
    IsDeleted boolean default 0
);
CREATE TABLE Tisch (
  TischID INT AUTO_INCREMENT PRIMARY KEY,
  Plaetze INT,
  Lage VARCHAR(50),
  IsDeleted BOOLEAN DEFAULT 0
);
CREATE TABLE Speise (
  SpeiseID INT AUTO_INCREMENT PRIMARY KEY,
  Bezeichnung VARCHAR(100),
  Beschreibung VARCHAR(255),
  Preis DECIMAL(6,2),
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

CREATE TABLE Login (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL
);
