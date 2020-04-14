-- =============================================
-- Autor:			Claudio Vargas y Eduardo Flores
-- Fecha:			31/05/2014
-- Descripción:		Creación de Procedimientos Almacenados para OnTime Proyect
-- Versión:			2.0
-- =============================================

USE bdOnTime;
GO

PRINT 'PROCEDIMIENTOS ASOCIADOS A DEPARTAMENTO'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertDepartamento'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertDepartamento]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertDepartamento]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertDepartamento]
	@pkDepartamento int= NULL OUTPUT,
	@txtNombre varchar(50),
	@fkJefe int
AS
	BEGIN
		INSERT INTO tblDepartamentos (txtNombre, fkJefe) VALUES (@txtNombre, @fkJefe);
		SET @pkDepartamento=@@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertDepartamento'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_UpdateDepartamento'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_UpdateDepartamento]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_UpdateDepartamento]
END
GO
CREATE PROCEDURE [dbo].[SP_UpdateDepartamento]
	@pkDepartamento int,
	@txtNombre varchar(50),
	@fkJefe int
AS
	BEGIN
		UPDATE tblDepartamentos SET
			txtNombre = @txtNombre, 
			fkJefe = @fkJefe
		WHERE pkDepartamento = @pkDepartamento;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_UpdateDepartamento'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetAllDepartamentos'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetAllDepartamentos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetAllDepartamentos]
END
GO
CREATE PROCEDURE [dbo].[SP_GetAllDepartamentos]
AS
	BEGIN
		SELECT pkDepartamento, txtNombre, fkJefe
		FROM tblDepartamentos
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetAllDepartamentos'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetDepartamentoByID'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetDepartamentoByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetDepartamentoByID]
END
GO
CREATE PROCEDURE [dbo].[SP_GetDepartamentoByID]
	@pkDepartamento int
AS
	BEGIN
		SELECT pkDepartamento, txtNombre, fkJefe
		FROM tblDepartamentos
		WHERE pkDepartamento = @pkDepartamento;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetDepartamentoByID'

PRINT 'PROCEDIMIENTOS ASOCIADOS A EMPLEADO'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertEmpleado'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertEmpleado]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertEmpleado]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertEmpleado]
	@pkEmpleado int= NULL OUTPUT,
	@txtNombre varchar(50),
	@txtApellidos varchar(50),
	@txtCI varchar(50),
	@dateFechaNacimiento date,
	@txtPassword varchar(50),
	@txtDireccion varchar(50),
	@txtTelefono varchar(50),
	@txtCorreo varchar(50),
	@dateFechaContrato date,	
	@intFlagEstado int,
	@intTipo int
AS
	BEGIN
		INSERT INTO tblEmpleados(txtNombre, txtApellidos, txtCI, dateFechaNacimiento, txtPassword, txtDireccion, txtTelefono, txtCorreo, dateFechaContrato, intFlagEstado, intTipo) VALUES (@txtNombre, @txtApellidos, @txtCI, @dateFechaNacimiento, CONVERT(varbinary, @txtPassword), @txtDireccion, @txtTelefono, @txtCorreo, @dateFechaContrato, @intFlagEstado, @intTipo);
		SET @pkEmpleado=@@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertEmpleado'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_UpdateEmpleado'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_UpdateEmpleado]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_UpdateEmpleado]
END
GO
CREATE PROCEDURE [dbo].[SP_UpdateEmpleado]
	@pkEmpleado int,
	@txtNombre varchar(50),
	@txtApellidos varchar(50),
	@txtCI varchar(50),
	@dateFechaNacimiento date,
	@txtPassword varchar(50),
	@txtDireccion varchar(50),
	@txtTelefono varchar(50),
	@txtCorreo varchar(50),
	@dateFechaContrato date,	
	@intFlagEstado int,
	@intTipo int
AS
	BEGIN
		UPDATE tblEmpleados SET	
			txtNombre = @txtNombre,
			txtApellidos = @txtApellidos,
			txtCI = @txtCI,
			dateFechaNacimiento = @dateFechaNacimiento,
			txtPassword = CONVERT(varbinary, @txtPassword),
			txtDireccion = @txtDireccion,
			txtTelefono = @txtTelefono,
			txtCorreo = @txtCorreo,
			dateFechaContrato = @dateFechaContrato,
			intFlagEstado = @intFlagEstado,
			intTipo = @intTipo
		WHERE pkEmpleado = @pkEmpleado;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_UpdateEmpleado'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetAllEmpleados'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetAllEmpleados]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetAllEmpleados]
END
GO
CREATE PROCEDURE [dbo].[SP_GetAllEmpleados]
AS
	BEGIN
		SELECT pkEmpleado, txtNombre, txtApellidos, txtCI, dateFechaNacimiento, txtPassword, txtDireccion, txtTelefono, txtCorreo, dateFechaContrato, intFlagEstado, intTipo
		FROM tblEmpleados
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetAllEmpleados'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetEmpleadoByID'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetEmpleadoByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetEmpleadoByID]
END
GO
CREATE PROCEDURE [dbo].[SP_GetEmpleadoByID]
	@pkEmpleado int
AS
	BEGIN
		SELECT pkEmpleado, txtNombre, txtApellidos, txtCI, dateFechaNacimiento, txtPassword, txtDireccion, txtTelefono, txtCorreo, dateFechaContrato, intFlagEstado, intTipo
		FROM tblEmpleados
		WHERE pkEmpleado = @pkEmpleado;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetEmpleadoByID'

PRINT 'PROCEDIMIENTOS ASOCIADOS A CARGO'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertCargo'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertCargo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertCargo]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertCargo]
	@pkCargo int= NULL OUTPUT,
	@txtNombre varchar(50),
	@fkDepartamento int
AS
	BEGIN
		INSERT INTO tblCargos (txtNombre, fkDepartamento) VALUES (@txtNombre, @fkDepartamento);
		SET @pkCargo=@@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertCargo'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_UpdateCargo'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_UpdateCargo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_UpdateCargo]
END
GO
CREATE PROCEDURE [dbo].[SP_UpdateCargo]
	@pkCargo int,
	@txtNombre varchar(50),
	@fkDepartamento int
AS
	BEGIN
		UPDATE tblCargos SET
			txtNombre = @txtNombre, 
			fkDepartamento = @fkDepartamento
		WHERE pkCargo = @pkCargo;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_UpdateCargo'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetAllCargos'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetAllCargos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetAllCargos]
END
GO
CREATE PROCEDURE [dbo].[SP_GetAllCargos]
AS
	BEGIN
		SELECT pkCargo, txtNombre, fkDepartamento
		FROM tblCargos
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetAllCargos'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetCargoByID'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetCargoByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetCargoByID]
END
GO
CREATE PROCEDURE [dbo].[SP_GetCargoByID]
	@pkCargo int
AS
	BEGIN
		SELECT pkCargo, txtNombre, fkDepartamento
		FROM tblCargos
		WHERE pkCargo = @pkCargo;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetCargoByID'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetCargosByIdDepartamento'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetCargosByIdDepartamento]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetCargosByIdDepartamento]
END
GO
CREATE PROCEDURE [dbo].[SP_GetCargosByIdDepartamento]
	@fkDepartamento int
AS
	BEGIN
		SELECT pkCargo, txtNombre, fkDepartamento
		FROM tblCargos
		WHERE fkDepartamento = @fkDepartamento;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetCargosByIdDepartamento'

PRINT 'PROCEDIMIENTOS ASOCIADOS A LA RELACION DE CARGOS Y EMPLEADOS'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertEmpCargo'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertEmpCargo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertEmpCargo]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertEmpCargo]
	@pkEmpCargo int = NULL OUTPUT,
	@fkEmpleado int,
	@fkCargo int
AS	
	BEGIN
		INSERT INTO tblEmpCargos (fkEmpleado, fkCargo) VALUES (@fkEmpleado, @fkCargo);
		SET @pkEmpCargo = @@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertEmpCargo'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetCargoByIdEmpleado'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetCargoByIdEmpleado]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetCargoByIdEmpleado]
END
GO
CREATE PROCEDURE [dbo].[SP_GetCargoByIdEmpleado]
	@fkEmpleado int
AS	
	BEGIN
		SELECT pkEmpCargo, fkEmpleado, fkCargo
		FROM tblEmpCargos
		WHERE fkEmpleado = @fkEmpleado;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetCargoByIdEmpleado'

PRINT 'PROCEDIMIENTOS ASOCIADOS A PERMISOS'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertPermiso'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertPermiso]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertPermiso]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertPermiso]
	@pkPermiso int= NULL OUTPUT,
	@txtDescripcion varchar(140),
	@intEstado int
AS
	BEGIN
		INSERT INTO tblPermisos (txtDescripcion, intEstado) VALUES (@txtDescripcion, @intEstado);
		SET @pkPermiso=@@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertPermiso'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_UpdatePermiso'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_UpdatePermiso]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_UpdatePermiso]
END
GO
CREATE PROCEDURE [dbo].[SP_UpdatePermiso]
	@pkPermiso int= NULL OUTPUT,
	@txtDescripcion varchar(140),
	@intEstado int
AS
	BEGIN
		UPDATE tblPermisos SET
			txtDescripcion = @txtDescripcion, 
			intEstado = @intEstado
		WHERE pkPermiso = @pkPermiso;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_UpdatePermiso'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetAllPermisos'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetAllPermisos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetAllPermisos]
END
GO
CREATE PROCEDURE [dbo].[SP_GetAllPermisos]
AS
	BEGIN
		SELECT pkPermiso, txtDescripcion, intEstado 
		FROM tblPermisos
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetAllPermisos'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetPermisoByID'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetPermisoByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetPermisoByID]
END
GO
CREATE PROCEDURE [dbo].[SP_GetPermisoByID]
	@pkPermiso int
AS
	BEGIN
		SELECT pkPermiso, txtDescripcion, intEstado 
		FROM tblPermisos
		WHERE pkPermiso = @pkPermiso;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetPermisoByID'

PRINT 'PROCEDIMIENTOS ASOCIADOS A LA RELACION ENTRE PERMISOS Y EMPLEADOS'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertEmpPermiso'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertEmpPermiso]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertEmpPermiso]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertEmpPermiso]
	@pkEmpPermiso int= NULL OUTPUT,
	@dateFechaInicio date,
	@dateFechaFin date,
	@datetimeHoraInicio datetime,
	@datetimeHoraFin datetime,
	@fkEmpleado int,
	@fkPermiso int
AS
	BEGIN
		INSERT INTO tblEmpPermisos (dateFechaInicio, dateFechaFin, datetimeHoraInicio, datetimeHoraFin, fkEmpleado, fkPermiso) VALUES (@dateFechaInicio, @dateFechaFin, @datetimeHoraInicio, @datetimeHoraFin, @fkEmpleado, @fkPermiso);
		SET @pkEmpPermiso=@@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertEmpPermiso'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_UpdateEmpPermiso'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_UpdateEmpPermiso]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_UpdateEmpPermiso]
END
GO
CREATE PROCEDURE [dbo].[SP_UpdateEmpPermiso]
	@pkEmpPermiso int,
	@dateFechaInicio date,
	@dateFechaFin date,
	@datetimeHoraInicio datetime,
	@datetimeHoraFin datetime,
	@fkEmpleado int,
	@fkPermiso int
AS
	BEGIN
		UPDATE tblEmpPermisos SET
			dateFechaInicio = @dateFechaInicio,
			dateFechaFin = @dateFechaFin,
			datetimeHoraInicio = @datetimeHoraInicio,
			datetimeHoraFin = @datetimeHoraFin,
			fkEmpleado = @fkEmpleado,
			fkPermiso = @fkPermiso
		WHERE pkEmpPermiso = @pkEmpPermiso;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_UpdateEmpPermiso'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetAllEmpPermisos'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetAllEmpPermisos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetAllEmpPermisos]
END
GO
CREATE PROCEDURE [dbo].[SP_GetAllEmpPermisos]
AS
	BEGIN
		SELECT pkEmpPermiso, dateFechaInicio, dateFechaFin, datetimeHoraInicio, datetimeHoraFin, fkEmpleado, fkPermiso
		FROM tblEmpPermisos
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetAllEmpPermisos'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetEmpPermisoByID'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetEmpPermisoByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetEmpPermisoByID]
END
GO
CREATE PROCEDURE [dbo].[SP_GetEmpPermisoByID]
	@pkEmpPermiso int
AS
	BEGIN
		SELECT pkEmpPermiso, dateFechaInicio, dateFechaFin, datetimeHoraInicio, datetimeHoraFin, fkEmpleado, fkPermiso
		FROM tblEmpPermisos
		WHERE pkEmpPermiso = @pkEmpPermiso;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetEmpPermisoByID'

PRINT 'PROCEDIMIENTOS ASOCIADOS A VACACIONES'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertVacacion'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertVacacion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertVacacion]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertVacacion]
	@pkVacacion int= NULL OUTPUT,
	@dateFechaInicio date,
	@dateFechaFin date,
	@fkEmpleado int,
	@fkAutorizacion int
AS
	BEGIN
		INSERT INTO tblVacaciones (dateFechaInicio, dateFechaFin, fkEmpleado, fkAutorizacion) VALUES (@dateFechaInicio, @dateFechaFin, @fkEmpleado, @fkAutorizacion);
		SET @pkVacacion=@@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertVacacion'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_UpdateVacacion'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_UpdateVacacion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_UpdateVacacion]
END
GO
CREATE PROCEDURE [dbo].[SP_UpdateVacacion]
	@pkVacacion int,
	@dateFechaInicio date,
	@dateFechaFin date,
	@fkEmpleado int,
	@fkAutorizacion int
AS
	BEGIN
		UPDATE tblVacaciones SET
			dateFechaInicio = @dateFechaInicio,
			dateFechaFin = @dateFechaFin,
			fkEmpleado = @fkEmpleado,
			fkAutorizacion = @fkAutorizacion
		WHERE pkVacacion = @pkVacacion;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_UpdateVacacion'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetAllVacaciones'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetAllVacaciones]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetAllVacaciones]
END
GO
CREATE PROCEDURE [dbo].[SP_GetAllVacaciones]
AS
	BEGIN
		SELECT pkVacacion, dateFechaInicio, dateFechaFin, fkEmpleado, fkAutorizacion
		FROM tblVacaciones
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetAllVacaciones'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetVacacionByID'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetVacacionByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetVacacionByID]
END
GO
CREATE PROCEDURE [dbo].[SP_GetVacacionByID]
	@pkVacacion int
AS
	BEGIN
		SELECT pkVacacion, dateFechaInicio, dateFechaFin, fkEmpleado, fkAutorizacion
		FROM tblVacaciones
		WHERE pkVacacion = @pkVacacion;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetVacacionByID'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetVacacionByIdEmpleado'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetVacacionByIdEmpleado]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetVacacionByIdEmpleado]
END
GO
CREATE PROCEDURE [dbo].[SP_GetVacacionByIdEmpleado]
	@fkEmpleado int
AS
	BEGIN
		SELECT pkVacacion, dateFechaInicio, dateFechaFin, fkEmpleado, fkAutorizacion
		FROM tblVacaciones
		WHERE fkEmpleado = @fkEmpleado;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetVacacionByIdEmpleado'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetVacacionByIdAutorizacion'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetVacacionByIdAutorizacion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetVacacionByIdAutorizacion]
END
GO
CREATE PROCEDURE [dbo].[SP_GetVacacionByIdAutorizacion]
	@fkAutorizacion int
AS
	BEGIN
		SELECT pkVacacion, dateFechaInicio, dateFechaFin, fkEmpleado, fkAutorizacion
		FROM tblVacaciones
		WHERE fkAutorizacion = @fkAutorizacion;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetVacacionByIdAutorizacion'

PRINT 'PROCEDIMIENTOS ASOCIADOS A MENSAJES'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertMensaje'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertMensaje]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertMensaje]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertMensaje]
	@pkMensaje int= NULL OUTPUT,
	@txtDescripcion varchar(140),
	@fkRemitente int
AS
	BEGIN
		INSERT INTO tblMensajes (txtDescripcion, fkRemitente) VALUES (@txtDescripcion, @fkRemitente);
		SET @pkMensaje=@@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertMensaje'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetAllMensajes'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetAllMensajes]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetAllMensajes]
END
GO
CREATE PROCEDURE [dbo].[SP_GetAllMensajes]
AS
	BEGIN
		SELECT pkMensaje, txtDescripcion, fkRemitente
		FROM tblMensajes
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetAllMensajes'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetMensajeByID'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetMensajeByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetMensajeByID]
END
GO
CREATE PROCEDURE [dbo].[SP_GetMensajeByID]
	@pkMensaje int
AS
	BEGIN
		SELECT pkMensaje, txtDescripcion, fkRemitente
		FROM tblMensajes
		WHERE pkMensaje = @pkMensaje;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetMensajeByID'

PRINT 'PROCEDIMIENTOS ASOCIADOS A HORARIO'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertHorario'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertHorario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertHorario]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertHorario]
	@pkHorario int = NULL OUTPUT,
	@txtNombre varchar(50),
	@tHoraEntrada varchar(50),
	@tHoraSalida varchar(50),
	@txtDias varchar(50),
	@intEstado int
AS	
	BEGIN
		INSERT INTO tblHorarios (txtNombre, tHoraEntrada, tHoraSalida, txtDias, intEstado) VALUES (@txtNombre, CONVERT(time(1),@tHoraEntrada), CONVERT(time(1),@tHoraSalida), @txtDias, @intEstado);
		SET @pkHorario = @@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertHorario'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_UpdateHorario'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_UpdateHorario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_UpdateHorario]
END
GO
CREATE PROCEDURE [dbo].[SP_UpdateHorario]
	@pkHorario int,
	@txtNombre varchar(50),
	@tHoraEntrada varchar(50),
	@tHoraSalida varchar(50),
	@txtDias varchar(50),
	@intEstado int
AS
	BEGIN
		UPDATE tblHorarios SET
			txtNombre = @txtNombre,
			tHoraEntrada = CONVERT(time(1),@tHoraEntrada),
			tHoraSalida = CONVERT(time(1),@tHoraSalida),
			txtDias = @txtDias,
			intEstado = @intEstado
		WHERE pkHorario = @pkHorario;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_UpdateHorario'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetAllHorarios'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetAllHorarios]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetAllHorarios]
END
GO
CREATE PROCEDURE [dbo].[SP_GetAllHorarios]
AS
	BEGIN
		SELECT pkHorario, txtNombre, tHoraEntrada, tHoraSalida, txtDias, intEstado
		FROM tblHorarios
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetAllHorarios'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetHorarioById'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetHorarioById]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetHorarioById]
END
GO
CREATE PROCEDURE [dbo].[SP_GetHorarioById]
	@pkHorario int
AS	
	BEGIN
		SELECT pkHorario, txtNombre, tHoraEntrada, tHoraSalida, txtDias, intEstado
		FROM tblHorarios
		WHERE pkHorario = @pkHorario;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetHorarioById'

PRINT 'PROCEDIMIENTOS ASOCIADOS A TURNO'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertTurno'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertTurno]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertTurno]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertTurno]
	@pkTurno  int = NULL OUTPUT,
	@txtNombre varchar(50),
	@intEstado int
AS	
	BEGIN
		INSERT INTO tblTurnos (txtNombre,intEstado) VALUES (@txtNombre, @intEstado);
		SET @pkTurno = @@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertTurno'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_UpdateTurno'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_UpdateTurno]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_UpdateTurno]
END
GO
CREATE PROCEDURE [dbo].[SP_UpdateTurno]
	@pkTurno int,
	@txtNombre varchar(50),
	@intEstado int
AS
	BEGIN
		UPDATE tblTurnos SET
			txtNombre = @txtNombre,
			intEstado = @intEstado
		WHERE pkTurno = @pkTurno;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_UpdateTurno'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetAllTurnos'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetAllTurnos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetAllTurnos]
END
GO
CREATE PROCEDURE [dbo].[SP_GetAllTurnos]
AS
	BEGIN
		SELECT pkTurno, txtNombre, intEstado
		FROM tblTurnos
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetAllTurnos'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetTurnoById'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetTurnoById]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetTurnoById]
END
GO
CREATE PROCEDURE [dbo].[SP_GetTurnoById]
	@pkTurno int
AS	
	BEGIN
		SELECT pkTurno, txtNombre, intEstado
		FROM tblTurnos
		WHERE pkTurno = @pkTurno;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetTurnoById'

PRINT 'PROCEDIMIENTOS ASOCIADOS A LA RELACION HORARIO TURNO'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertHoTurno'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertHoTurno]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertHoTurno]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertHoTurno]
	@pkHoTurno  int = NULL OUTPUT,
	@fkHorario int,
	@fkTurno int
AS	
	BEGIN
		INSERT INTO tblHoTurnos (fkHorario, fkTurno) VALUES (@fkHorario, @fkTurno);
		SET @pkHoTurno = @@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertHoTurno'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_UpdateHoTurno'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_UpdateHoTurno]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_UpdateHoTurno]
END
GO
CREATE PROCEDURE [dbo].[SP_UpdateHoTurno]
	@pkHoTurno  int,
	@fkHorario int,
	@fkTurno int
AS
	BEGIN
		UPDATE tblHoTurnos SET
			fkHorario = @fkHorario,
			fkTurno = @fkTurno
		WHERE pkHoTurno = @pkHoTurno;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_UpdateHoTurno'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetHoTurnoById'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetHoTurnoById]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetHoTurnoById]
END
GO
CREATE PROCEDURE [dbo].[SP_GetHoTurnoById]
	@pkHoTurno int
AS	
	BEGIN
		SELECT pkHoTurno, fkHorario, fkTurno
		FROM tblHoTurnos
		WHERE pkHoTurno = @pkHoTurno;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetHoTurnoById'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetHoTurnoByIdTurno'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetHoTurnoByIdTurno]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetHoTurnoByIdTurno]
END
GO
CREATE PROCEDURE [dbo].[SP_GetHoTurnoByIdTurno]
	@fkTurno int
AS	
	BEGIN
		SELECT pkHoTurno, fkHorario, fkTurno
		FROM tblHoTurnos
		WHERE fkTurno = @fkTurno;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetHoTurnoByIdTurno'

PRINT 'PROCEDIMIENTOS ASOCIADOS A LA RELACION HORARIO TURNO Y EMPLEADO	'
PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_InsertHTEmpleado'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_InsertHTEmpleado]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_InsertHTEmpleado]
END
GO
CREATE PROCEDURE [dbo].[SP_InsertHTEmpleado]
	@pkHTEmpleado int = NULL OUTPUT,
	@fkHoTurno int,
	@fkEmpleado int
AS	
	BEGIN
		INSERT INTO tblHTEmpleados (fkHoTurno, fkEmpleado) VALUES (@fkHoTurno, @fkEmpleado);
		SET @pkHTEmpleado = @@IDENTITY;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_InsertHTEmpleado'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_UpdateHTEmpleado'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_UpdateHTEmpleado]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_UpdateHTEmpleado]
END
GO
CREATE PROCEDURE [dbo].[SP_UpdateHTEmpleado]
	@pkHTEmpleado int,
	@fkHoTurno int,
	@fkEmpleado int
AS
	BEGIN
		UPDATE tblHTEmpleados SET
			fkHoTurno = @fkHoTurno,
			fkEmpleado = @fkEmpleado
		WHERE pkHTEmpleado = @pkHTEmpleado;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_UpdateHTEmpleado'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetHTEmpleadoById'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetHTEmpleadoById]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetHTEmpleadoById]
END
GO
CREATE PROCEDURE [dbo].[SP_GetHTEmpleadoById]
	@pkHTEmpleado int
AS	
	BEGIN
		SELECT pkHTEmpleado, fkHoTurno, fkEmpleado
		FROM tblHTEmpleados
		WHERE pkHTEmpleado = @pkHTEmpleado;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetHTEmpleadoById'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_GetHTEmpleadoByIdEmpleado'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_GetHTEmpleadoByIdEmpleado]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_GetHTEmpleadoByIdEmpleado]
END
GO
CREATE PROCEDURE [dbo].[SP_GetHTEmpleadoByIdEmpleado]
	@fkEmpleado int
AS	
	BEGIN
		SELECT pkHTEmpleado, fkHoTurno, fkEmpleado
		FROM tblHTEmpleados
		WHERE fkEmpleado = @fkEmpleado;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_GetHTEmpleadoByIdEmpleado'

PRINT 'INICIANDO CREACION DEL PROCEDIMIENTO SP_DeleteHTEmpleadoById'
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[SP_DeleteHTEmpleadoById]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[SP_DeleteHTEmpleadoById]
END
GO
CREATE PROCEDURE [dbo].[SP_DeleteHTEmpleadoById]
	@pkHTEmpleado int
AS	
	BEGIN
		DELETE FROM tblHTEmpleados
		WHERE pkHTEmpleado = @pkHTEmpleado;
	END

PRINT 'FIN DE PROCEDIMIENTO SP_DeleteHTEmpleadoById'







