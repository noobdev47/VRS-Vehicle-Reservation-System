CREATE TABLE [dbo].[Car] (
    [CAR_ID]       INT          NOT NULL,
    [CAR_NAME]     VARCHAR (50) NOT NULL,
    [CATEGORY]     VARCHAR (50) NOT NULL,
    [COLOR]        VARCHAR (50) NOT NULL,
    [MFG_DATE]     TEXT         NOT NULL,
    [INSURANCE_NO] FLOAT (53)   NOT NULL,
    [REG_NO]       TEXT         NOT NULL,
    [RATE_PER_DAY]        FLOAT (53)   NOT NULL,
    [STATUS]       VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CAR_ID] ASC)
);

