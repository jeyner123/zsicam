SET SCAN OFF
CREATE OR REPLACE
PACKAGE BODY zsi_wsa_lib IS

   /*
   =======================================================================
   *
   * Copyright (c) 20014-2014 by ZSI.  All rights reserved.
   *
   * Redistribution and use in source and binary forms, with or without
   * modification is strictly prohibited.
   *
   ===========================================================================================================================
   */

   /* Modification History
   Date       By    History
   ---------  ----  ----------------------------------------------------------------------------------------------------------
   20-OCT-14  BD    New
   */

   TYPE VC2_255_ARR  IS TABLE OF VARCHAR2(255)  INDEX BY BINARY_INTEGER;
   l_mac_addr        vc2_255_arr;
   l_mac_index       NUMBER(3) := 0;

   FUNCTION GenerateIndex RETURN NUMBER IS
   BEGIN
      l_mac_index := l_mac_index + 1;
      RETURN l_mac_index;
   END;

   FUNCTION IsMACValid (p_mac_addr IN VARCHAR2) RETURN VARCHAR2 IS
   BEGIN
      FOR i IN 1..l_mac_addr.COUNT LOOP
         IF UPPER(p_mac_addr) = UPPER(l_mac_addr(i)) THEN
            RETURN 'Y';
         END IF;
      END LOOP;
      RETURN 'N';
   END;

BEGIN

   l_mac_addr(GenerateIndex) := 'BEGIN';
   l_mac_addr(GenerateIndex) := 'LAST';

END;
/
SHOW ERRORS