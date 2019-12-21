CREATE TABLE [dbo].[Customer] (
    [CUSTOMER_ID] INT          NOT NULL,
    [NAME]        VARCHAR (50) NOT NULL,
    [LICENSE_NO]  INT          NOT NULL,
    [CNIC]        FLOAT (53)   NOT NULL,
    [PHONE]       FLOAT (53)   NOT NULL,
    [DOB]         DATE         NOT NULL,
    [ADDRESS]     TEXT         NOT NULL,
    PRIMARY KEY CLUSTERED ([CUSTOMER_ID] ASC)
);

