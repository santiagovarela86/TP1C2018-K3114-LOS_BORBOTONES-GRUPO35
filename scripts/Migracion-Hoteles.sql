
CREATE PROCEDURE MIGRATE_HOTEL
AS BEGIN

  
  INSERT INTO GD1C2018.LOS_BORBOTONES.Direccion (Ciudad,Calle,NumeroCalle)
	SELECT Hotel_Ciudad
      ,Hotel_Calle
      ,Hotel_Nro_Calle
	FROM GD1C2018.gd_esquema.Maestra
	GROUP BY Hotel_Ciudad
      ,Hotel_Calle
      ,Hotel_Nro_Calle;

	  INSERT INTO GD1C2018.LOS_BORBOTONES.Categoria(Estrellas,RecargaEstrellas)
	  SELECT Hotel_CantEstrella, Hotel_Recarga_Estrella FROM GD1C2018.gd_esquema.Maestra
	  GROUP BY Hotel_CantEstrella, Hotel_Recarga_Estrella;


	  INSERT INTO GD1C2018.LOS_BORBOTONES.Hotel (idCategoria,idDireccion)
	  SELECT CAT.idCategoria, DIR.idDireccion FROM GD1C2018.LOS_BORBOTONES.Categoria AS CAT
	  JOIN  GD1C2018.gd_esquema.Maestra AS MAS ON MAS.Hotel_CantEstrella = CAT.Estrellas AND MAS.Hotel_Recarga_Estrella = CAT.RecargaEstrellas
	  JOIN GD1C2018.LOS_BORBOTONES.Direccion AS DIR ON MAS.Hotel_Ciudad = DIR.Ciudad AND MAS.Hotel_Calle = DIR.Calle AND MAS.Hotel_Nro_Calle = DIR.NumeroCalle;
END
  
DROP PROCEDURE MIGRATE_HOTEL;
 
EXECUTE  MIGRATE_HOTEL;