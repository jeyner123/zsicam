SET SCAN OFF
CREATE OR REPLACE
PACKAGE zsi_wsa_lib IS


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


   FUNCTION IsMACValid (p_mac_addr IN VARCHAR2) RETURN VARCHAR2;


 END zsi_wsa_lib;
 /