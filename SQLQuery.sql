
CREATE TABLE [dbo].[Decks] (
    [DeckId]   INT            IDENTITY (1, 1) NOT NULL,
    [DeckName] NVARCHAR (100) NOT NULL,
    [Stat1]    NVARCHAR (100) NOT NULL,
    [Stat2]    NVARCHAR (100) NOT NULL,
    [Stat3]    NVARCHAR (100) NOT NULL,
    [Stat4]    NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Decks] PRIMARY KEY CLUSTERED ([DeckId] ASC)
);



CREATE TABLE [dbo].[Cards] (
    [CardId]      INT            IDENTITY (1, 1) NOT NULL,
    [CardName]    NVARCHAR (100) NOT NULL,
    [Stat1]       INT            NOT NULL,
    [Stat2]       INT            NOT NULL,
    [Stat3]       INT            NOT NULL,
    [Stat4]       INT            NOT NULL,
    [DeckId]      INT            NOT NULL,
    [Image]       NVARCHAR (255) NULL,
    [Description] NVARCHAR (255) NULL,
    CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED ([CardId] ASC),
    CONSTRAINT [FK_Cards_Decks_DeckId] FOREIGN KEY ([DeckId]) REFERENCES [dbo].[Decks] ([DeckId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Cards_DeckId]
    ON [dbo].[Cards]([DeckId] ASC);



SET IDENTITY_INSERT dbo.decks ON;
INSERT INTO dbo.Decks (DeckId, DeckName, Stat1, Stat2, Stat3, Stat4)
VALUES (1, Animals, 'Agility', 'Speed', 'Power', 'Stealth');

INSERT INTO dbo.Cards (DeckId, CardName, Stat1, Stat2, Stat3, Stat4)
VALUES 

(1,'Lion', 90, 70, 92, 85),
(1,'Cheetah', 80, 95, 88, 75),
(1,'Eagle', 80, 88, 90, 80),
(1,'Gorilla', 98, 75, 85, 90),
(1,'Sloth bear', 88, 50, 75, 55),
(1, 'Black panther', 90, 88, 85, 92),
(1, 'Tiger', 95, 80, 95, 82),
(1, 'Wolf', 88, 75, 85, 80),
(1, 'Monkey', 75, 80, 70, 88),
(1, 'Elephant', 92, 60, 95, 65); 


SET IDENTITY_INSERT dbo.decks ON;
INSERT INTO dbo.Decks (DeckId, DeckName, Stat1, Stat2, Stat3, Stat4)
VALUES (2, 'Superheroes', 'Strength', 'Speed', 'Power', 'Stamina');
SET IDENTITY_INSERT dbo.decks OFF;


INSERT INTO dbo.Cards (DeckId, CardName, Stat1, Stat2, Stat3, Stat4)
VALUES 
(2, 'Superman', 80, 95, 75, 90),
(2, 'Green latern', 90, 95, 50, 60),
(2, 'Flash', 80, 99, 60, 77),
(2, 'Spiderman', 90, 80, 80, 80),
(2, 'Batman', 88, 70, 90, 77),
(2, 'Wonderwoman', 90, 88, 95, 80),
(2, 'Superwoman', 82, 89, 78, 86),
(2, 'Black Widow', 66, 78, 88, 90),
(2, 'Thor', 80, 90, 95, 88);




SET IDENTITY_INSERT dbo.decks ON;
INSERT INTO dbo.Decks (DeckId, DeckName, Stat1, Stat2, Stat3, Stat4)
VALUES (3, 'Historical Figures', 'Wisdom', 'Leadership', 'Intelligence', 'Charisma');
SET IDENTITY_INSERT dbo.decks OFF;


INSERT INTO dbo.Cards (DeckId, CardName, Stat1, Stat2, Stat3, Stat4)
VALUES 
(3, 'Abraham licoln', 90, 85, 80, 75),
(3, 'Cleopatra', 85, 90, 80, 75),
(3, 'Genghis Khan', 95, 88, 92, 90),
(3, 'Joan of Arc', 85, 88, 75, 85),
(3, 'Leonardo De Vinci', 90, 85, 80, 75),
(3, 'Winston Churchill', 85, 90, 88, 82),
(3, 'Queen Elizabeth I', 85, 90, 88, 82),
(3, 'Nelson Mandela', 85, 90, 88, 85),
(3, 'Albert Einstein', 90, 85, 80 ,75),
(3, 'Marie Curie', 90, 85, 78, 82);





















SET IDENTITY_INSERT dbo.decks ON;
INSERT INTO dbo.Decks (DeckId, DeckName, Stat1, Stat2, Stat3, Stat4)
VALUES (4, 'Movie Characters', 'Resilience', 'Courage', 'Resourcefullness', 'Magic');
SET IDENTITY_INSERT dbo.decks OFF;


INSERT INTO dbo.Cards (DeckId, CardName, Stat1, Stat2, Stat3, Stat4)
VALUES 
(4, 'James Bond', 90, 80, 85, 85),
(4, 'Hanibal Lector', 90, 85, 88, 75),
(4, 'Wonder Woman', 92, 95, 90 ,85),
(4, 'Spider man', 90, 85, 88, 80),
(4, 'Harry Potter', 90, 85, 88, 80),
(4, 'Darth Vader', 92, 95, 90, 85),
(4, 'Indiana Jones', 85, 90, 88, 90),
(4, 'Marta Mcfly', 90, 85, 88, 75),
(4, 'Elsa', 90, 85, 88, 80),
(4, 'Luke Skywalker', 90, 85, 88, 90);



SET IDENTITY_INSERT dbo.decks ON;
INSERT INTO dbo.Decks (DeckId, DeckName, Stat1, Stat2, Stat3, Stat4)
VALUES (5, 'Mythology Creatures', 'Ferocity', 'Charm', 'Immortality', 'Regeneration');
SET IDENTITY_INSERT dbo.decks OFF;

INSERT INTO dbo.Cards (DeckId, CardName, Stat1, Stat2, Stat3, Stat4)
VALUES 
(5, 'Dragon', 90, 85,88, 92),
(5, 'Phoenix', 92, 88, 85, 90),
(5, 'Minotaur', 80, 90, 85, 78),
(5, 'Sphinx', 90, 85, 88, 80),
(5, 'Kraken', 88, 90, 85, 92),
(5, 'Cerberus', 92, 88, 85, 90),
(5, 'Medusa', 90, 85, 88, 80),
(5, 'Griffin', 85, 90, 88, 90),
(5, 'Kitsune', 88, 90, 85, 80),
(5, 'Unicorn', 90, 85, 88, 90);




