Feature: RegistrarExpediente
	para comenzar a realizar el cobro de la cartera
	Como secretaria
	Quiero registrar un expediente

@mytag
Scenario Outline: Registro de Expediente exitoso
	Given logueado en el sistema
	And luego de haber consultado las carteras
	And selecciono una cartera
	And relleno la informacion requerida
	And subo el documento con <ubicacion>
	When presione el boton subir archivo
	Then el sistema me responde "Hecho"
	Examples: 
	| ubicacion                                     |
	| C:\Windows\Web\Wallpaper\Theme2\img8.jpg		|
	| C:\Windows\Web\Wallpaper\Windows\img0.jpg     |
