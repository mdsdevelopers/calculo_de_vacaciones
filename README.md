# calculo_de_vacaciones
calculo para correr anualmente el 31/11


Para utlizarlo, no hay mas que cambiar el año de calculo (en una clase llamada EntryPoint) y luego correr el TestEntryPoint (que es el mejor nombre que se me ocurrio en ese momento) como punto de entrada al calculo.

Los resultados se guardan en la tabla Tmp_Authorizaciones_Net (que hay qeu truncar antes de correr el calculo) para que la revise faby, y cuando dá el OK, se insertan esos resultados en la tabla autorizaciones_licencias.

Y eso es todo!

La tabla autorizaciones_licencias pide un concepto, que deberia ser el 1 (vacaciones).
el periodo es el del año calculado.
el id es secuencial.
el legajo y dias_autorizados son los que vienen de la tabla Tmp_Authorizaciones_Net 
los dias tomados son 0 (cero)

Y listo!. Va el proyecto entero adjunto.

COMO EL ID NO ES AUTONUMERICO, CREAMOS UN CURSOR PARA MIGRAR LOS DATOS DE LA TEMPORAL A AUTORIZACIONES_LICENCIAS

declare 
	 @id_interna int, @Dias_Autorizados int, 
	 @Id_Concepto_Licencia int, @Periodo int,
	 @IdAutoInc int, @Dias_Tomados int


set @IdAutoInc = (select max(id) + 1
from DBO.autorizaciones_licencias)

DECLARE cur CURSOR
FOR
select legajo Id_Interna, dias Dias_Autorizados, 1 Id_Concepto_Licencia, 2015 Periodo, 0 Dias_Tomados
from Tmp_Authorizaciones_Net

OPEN CUR

FETCH NEXT FROM CUR 
INTO @id_interna, @Dias_Autorizados, @Id_Concepto_Licencia, @Periodo, @Dias_Tomados

WHILE @@FETCH_STATUS = 0
BEGIN
    
    
    print '' + cast(@id_interna as varchar) + ' ' +
			   cast(@Dias_Autorizados as varchar) +  ' ' +
			   cast(@Id_Concepto_Licencia as varchar) +  ' ' +
			   cast(@Periodo as varchar) +  ' ' +
			   cast(@IdAutoInc as varchar) +  ' ' +
			   cast(@Dias_Tomados as varchar)
    
    --INSERT INTO dbo.Autorizaciones_Licencias (Id_Interna, Dias_Autorizados, Id_Concepto_Licencia, Periodo, Id, Dias_Tomados)
    --values (@id_interna, @Dias_Autorizados, @Id_Concepto_Licencia, @Periodo, @IdAutoInc, @Dias_Tomados)
    
    
    SET @IdAutoInc = @IdAutoInc + 1
    
    FETCH NEXT FROM CUR 
	INTO @id_interna, @Dias_Autorizados, @Id_Concepto_Licencia, @Periodo, @Dias_Tomados


END 
CLOSE cur
DEALLOCATE cur