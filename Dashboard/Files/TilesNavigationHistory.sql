-- Table: public.TilesNavigationHistory

-- DROP TABLE IF EXISTS public."TilesNavigationHistory";

CREATE TABLE IF NOT EXISTS public."TilesNavigationHistory"
(
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "CreatedOn" timestamp without time zone NOT NULL,
    "TileId" integer NOT NULL,
    CONSTRAINT "PK_TilesNavigationHistory" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TilesNavigationHistory"
    OWNER to postgres;