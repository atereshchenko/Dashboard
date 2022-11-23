-- Table: public.Tiles

-- DROP TABLE IF EXISTS public."Tiles";

CREATE TABLE IF NOT EXISTS public."Tiles"
(
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Number" integer NOT NULL,
    "Name" text COLLATE pg_catalog."default",
    "Description" text COLLATE pg_catalog."default",
    "Link" text COLLATE pg_catalog."default",
    "LinkName" text COLLATE pg_catalog."default",
    "TurnOn" boolean NOT NULL,
    "TextColorId" integer,
    "BorderColorId" integer,
    CONSTRAINT "PK_Tiles" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Tiles"
    OWNER to postgres;