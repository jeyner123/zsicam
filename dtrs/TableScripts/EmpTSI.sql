DROP TABLE EMPTSI CASCADE CONSTRAINTS;

CREATE TABLE EMPTSI
(
  EMPL_ID_NO     NUMBER,
  IMG            BLOB,
  RTF            BLOB,
  RIF            BLOB,
  RMF            BLOB,
  RRF            BLOB,
  RSF            BLOB,
  LTF            BLOB,
  LIF            BLOB,
  LMF            BLOB,
  LRF            BLOB,
  LSF            BLOB,
  TSI            VARCHAR2(10 BYTE),
  CREATED_BY     VARCHAR2(100 BYTE),
  DATE_CREATED   DATE,
  MODIFIED_BY    VARCHAR2(100 BYTE),
  DATE_MODIFIED  DATE
)
TABLESPACE HRIS
PCTUSED    0
PCTFREE    10
INITRANS   1
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            NEXT             1M
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
           )
LOGGING 
NOCOMPRESS 
NOCACHE
NOPARALLEL
MONITORING;

COMMENT ON TABLE EMPTSI IS 'EMPLOYEE TEMPLATE SEARCH INDEX';

/
