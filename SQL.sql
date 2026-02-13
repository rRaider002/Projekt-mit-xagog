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
    Vorname varchar(20),
    Nachname varchar(20),
    Telefon varchar(11),
    passwort_hash varchar(25),
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

select * from Mitarbeiter;
