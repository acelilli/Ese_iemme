   M S B A M L   `   `   `  ����E  ATask_Batch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Task_Batch
Task_Batch  5   	       Task_Batch.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Task_Batch     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      ]� .+�5
   
   �� 
����İ�$	��200��61   .+�5      �� -   5         ��Name$ 
btn_mostra��5      $��
15,15,15,5q�6)   $��16(�6=   
����d�.��6�   Anteprima Persona6�   �� 5      -   5        $ btn_scrivi_persona��5      $
��15,5q�61   $��16(�6?   
����d�.��6�   Scrivi Dati di Persona6�   �� 5      -   5        $ btn_mostra_CF��5      $
��15,5q�6,   $��16(�6:   
����d�.��6�   Anteprima CF6�   �� 5      -   5        $ btn_scrivi_cf��5      $
��15,5q�6,   $��16(�6:   
����d�.��6�   Scrivi Dati di CF6�   �� 5      -   5        $ btn_to_mongoDb��5      $��15,30q�6-   $��16(�6<   
����d�.��6�   	MongoDb6�   5      � 5   
   $	��297��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��	dgPersona��5         AutoGenerateColumns$ False��6(   $��0,0,0,0q�6D      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$
 Nome��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Nome+6R     5!      $ Cognome��6)    6:   �� *	Cognome+6X     5"      $ Email��6)    68   �� *Email+6T     5#      $ Telefono��6)    6;   �� *
Telefono+6Z   5&      5'      � 5(   
   .+�5*        -   5        $
��dgCF��5*      $ False��6#   $��0,0,0,0q�6?    5+        5,      $ Codice Fiscale��6)    6A   �� *CodFis+6^     5-      $ Data Emissione��6)    6A   �� *DataEmissione+6e     5.      $ Data Scadenza��6)    6@   �� *DataScadenza+6c   50      51      54      55      