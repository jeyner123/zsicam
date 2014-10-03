CREATE OR REPLACE PROCEDURE EmpTSI_update (
    p_empl_id_no  IN number
   ,p_tsi         IN VARCHAR2 default NULL 
   ,p_user_id     IN VARCHAR2 default NULL   
   ,p_img         IN blob default NULL
   ,p_rtf         IN blob default NULL
   ,p_rif         IN blob default NULL
   ,p_rmf         IN blob default NULL
   ,p_rrf         IN blob default NULL
   ,p_rsf         IN blob default NULL
   ,p_ltf         IN blob default NULL
   ,p_lif         IN blob default NULL
   ,p_lmf         IN blob default NULL
   ,p_lrf         IN blob default NULL
   ,p_lsf         IN blob default NULL
) AS
   
/*
   ========================================================================
   *
   * Copyright (c) 2014 ZettaSolution, Inc.  All rights reserved.
   *
   * Redistribution and use in source and binary forms, with or without
   * modification is strictly prohibited.
   *
   ========================================================================

   Date       By    History
   ---------  ----  ---------------------------------------------------------------------
   03-OCT-14  GT    New
*/

   --DECLARATION SECTION
   l_recCount                   NUMBER := 0;


  BEGIN
     SELECT COUNT(*) INTO l_recCount FROM EMPTSI WHERE empl_id_no = p_empl_id_no;    
     IF l_recCount = 0 THEN
        INSERT INTO EMPTSI (
                            empl_id_no  
                           ,img         
                           ,rtf         
                           ,rif         
                           ,rmf         
                           ,rrf         
                           ,rsf         
                           ,ltf         
                           ,lif         
                           ,lmf         
                           ,lrf         
                           ,lsf         
                           ,tsi         
                           ,created_by  
                           ,date_created)
                    VALUES (
                            p_empl_id_no   
                           ,p_img         
                           ,p_rtf         
                           ,p_rif         
                           ,p_rmf         
                           ,p_rrf         
                           ,p_rsf         
                           ,p_ltf         
                           ,p_lif         
                           ,p_lmf         
                           ,p_lrf         
                           ,p_lsf         
                           ,p_tsi         
                           ,p_user_id
                           ,SYSDATE);
     ELSE

          UPDATE EMPTSI SET empl_id_no    = p_empl_id_no   
                           ,img           = p_img         
                           ,rtf           = p_rtf         
                           ,rif           = p_rif         
                           ,rmf           = p_rmf         
                           ,rrf           = p_rrf         
                           ,rsf           = p_rsf         
                           ,ltf           = p_ltf         
                           ,lif           = p_lif         
                           ,lmf           = p_lmf         
                           ,lrf           = p_lrf         
                           ,lsf           = p_lsf         
                           ,tsi           = p_tsi         
                           ,modified_by   = p_user_id
                           ,date_modified = SYSDATE
                      WHERE empl_id_no = p_empl_id_no; 
     END IF;
END;
/
SHOW ERROR;
