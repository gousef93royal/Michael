CREATE TABLE Account
  (
    Account_Nr                  INTEGER NOT NULL ,
    RFID_Nr                     CHAR (30) NOT NULL ,
    Account_Bal                 NUMBER NOT NULL ,
    Email                       VARCHAR2 (30) NOT NULL ,
    Phone                       NUMBER ,
    First_Name                  VARCHAR2 (30) ,
    Last_Name                   VARCHAR2 (30) NOT NULL ,
    Payment_Status              CHAR (1) NOT NULL ,
    PayInAdvance                CHAR (1) ,
    Rsvp_Camp_Rvsp_Nr           NUMBER NOT NULL ,
    Item_invoice_Item_InvoiceID INTEGER NOT NULL ,
    Invoice_Food_InvoiceID      INTEGER NOT NULL ,
    Group_Camping_Group_Nr      INTEGER NOT NULL
  ) ;
ALTER TABLE Account ADD CONSTRAINT Account_PK PRIMARY KEY ( Account_Nr ) ;
CREATE TABLE Camp
  (
    CampID      INTEGER NOT NULL ,
    Description VARCHAR2 (200) ,
    MaxPersons  NUMBER NOT NULL ,
    Available   CHAR (1)
  ) ;
ALTER TABLE Camp ADD CONSTRAINT Camp_PK PRIMARY KEY ( CampID ) ;
CREATE TABLE Food
  (
    FoodID       INTEGER NOT NULL ,
    FoodName     VARCHAR2 (100) NOT NULL ,
    FoodQuantity INTEGER NOT NULL ,
    FoodPrice    NUMBER NOT NULL ,
    FoodType     VARCHAR2 (20) NOT NULL
  ) ;
ALTER TABLE Food ADD CONSTRAINT Food_PK PRIMARY KEY ( FoodID ) ;
CREATE TABLE Group_Camping
  (
    Group_Nr   INTEGER NOT NULL ,
    Main_Email VARCHAR2
    --  ERROR: VARCHAR2 size not specified
    NOT NULL ,
    Rsvp_Nr           NUMBER NOT NULL ,
    "Check-in_Status" CHAR (1) NOT NULL ,
    Account_nr        INTEGER NOT NULL
  ) ;
ALTER TABLE Group_Camping ADD CONSTRAINT Group_Camping_PK PRIMARY KEY ( Group_Nr ) ;
CREATE TABLE Invoice_Food
  (
    InvoiceID   INTEGER NOT NULL ,
    AccountNr   INTEGER NOT NULL ,
    FoodID      INTEGER NOT NULL ,
    Food_FoodID INTEGER NOT NULL
  ) ;
ALTER TABLE Invoice_Food ADD CONSTRAINT Invoice_Food_PK PRIMARY KEY ( InvoiceID ) ;
CREATE TABLE Item_invoice
  (
    Item_InvoiceID INTEGER NOT NULL ,
    Account_Nr     INTEGER NOT NULL ,
    Loan_Status    CHAR (1) NOT NULL ,
    Item_ID        INTEGER ,
    Items_Item_ID  INTEGER NOT NULL
  ) ;
ALTER TABLE Item_invoice ADD CONSTRAINT Item_invoice_PK PRIMARY KEY ( Item_InvoiceID ) ;
CREATE TABLE Items
  (
    Item_ID           INTEGER NOT NULL ,
    Name              VARCHAR2 (100) NOT NULL ,
    DepositAmount     NUMBER NOT NULL ,
    LoanPrice         NUMBER ,
    Item_Description  VARCHAR2 (200) ,
    Item_Quantity     NUMBER NOT NULL ,
    "Item_Available " CHAR (1) NOT NULL
  ) ;
ALTER TABLE Items ADD CONSTRAINT Rent_Material_PK PRIMARY KEY ( Item_ID ) ;
CREATE TABLE Rsvp_Camp
  (
    Rvsp_Nr     NUMBER NOT NULL ,
    Start_Date  DATE NOT NULL ,
    End_Date    DATE NOT NULL ,
    Account_Nr  INTEGER NOT NULL ,
    CampID      INTEGER NOT NULL ,
    Camp_CampID INTEGER NOT NULL
  ) ;
ALTER TABLE Rsvp_Camp ADD CONSTRAINT Rsvp_Camp_PK PRIMARY KEY ( Rvsp_Nr ) ;
ALTER TABLE Account ADD CONSTRAINT Account_Group_Camping_FK FOREIGN KEY ( Group_Camping_Group_Nr ) REFERENCES Group_Camping ( Group_Nr ) ;
ALTER TABLE Account ADD CONSTRAINT Account_Invoice_Food_FK FOREIGN KEY ( Invoice_Food_InvoiceID ) REFERENCES Invoice_Food ( InvoiceID ) ;
ALTER TABLE Account ADD CONSTRAINT Account_Item_invoice_FK FOREIGN KEY ( Item_invoice_Item_InvoiceID ) REFERENCES Item_invoice ( Item_InvoiceID ) ;
ALTER TABLE Account ADD CONSTRAINT Account_Rsvp_Camp_FK FOREIGN KEY ( Rsvp_Camp_Rvsp_Nr ) REFERENCES Rsvp_Camp ( Rvsp_Nr ) ;
ALTER TABLE Invoice_Food ADD CONSTRAINT Invoice_Food_Food_FK FOREIGN KEY ( Food_FoodID ) REFERENCES Food ( FoodID ) ;
ALTER TABLE Item_invoice ADD CONSTRAINT Item_invoice_Items_FK FOREIGN KEY ( Items_Item_ID ) REFERENCES Items ( Item_ID ) ;
ALTER TABLE Rsvp_Camp ADD CONSTRAINT Rsvp_Camp_Camp_FK FOREIGN KEY ( Camp_CampID ) REFERENCES Camp ( CampID ) ;
