CREATE SEQUENCE movie_id_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1;

Create Table Movies (Id bigint DEFAULT nextval('movie_id_seq'::regclass) NOT NULL PRIMARY KEY,
                     Title character varying(255) NOT NULL UNIQUE);

INSERT INTO Movies (Title) VALUES ('Thor');

INSERT INTO Movies (Title) VALUES ('Hulk');

INSERT INTO Movies (Title) VALUES ('Ironman');
