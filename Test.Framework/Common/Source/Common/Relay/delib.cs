

// ****************************************************************************
// ****************************************************************************
// ****************************************************************************
// ****************************************************************************
// ****************************************************************************
//
//
// delib.cs
//
//
// ****************************************************************************
// ****************************************************************************
// ****************************************************************************
// ****************************************************************************
// ****************************************************************************
//
//



//-----------------------------------------------------------------------------
// Export der DeLib-Funktionen über einen Wrapper
//
// Auch hier gilt:
// Die Enumerationen und Konstanten müssen aus dem C-Header in einen .NET-
// kompatiblen Konstanten oder Enumerationstype überführt werden.
// 
// Für die Funktionsprototypen muss ein kompatibler CLS-Datentyp genommen 
// werden. Für manche C-/C++-datentypen gibt es einen solchen Datentyp nicht,
// dann muss ein Marshalling erfolgen (meist in erbindung mit ANSI und Unicode
// bei Zeichenketten).
//
// Wenn Aufrufe fehlschlagen sind meisten die verwendeten Datentypen daran
// Schuld.
//
//-----------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Relay
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class DeLibNET
    {

        public enum ModuleID
        {
			// all Modul-ID's
            USB_Interface8 					= 0x0001,
            USB_CAN_STICK 					= 0x0002,
            USB_LOGI_500 					= 0x0003,
            RO_USB2 						= 0x0004,
            RO_SER 							= 0x0005,
            USB_BITP_200 					= 0x0006,
            RO_USB1 						= 0x0007,
			RO_USB							= 0x0007,
            RO_ETH 							= 0x0008,
            USB_MINI_STICK 					= 0x0009,
            USB_LOGI_18 					= 0x000a,
            RO_CAN 							= 0x000b,
            USB_SPI_MON 					= 0x000c,
            USB_WATCHDOG 					= 0x000d,
			USB_OPTOIN_8 					= 0x000e,
			USB_relays_8 					= 0x000e,
			USB_OPTOIN_8_relays_8 			= 0x000f,
			USB_OPTOIN_16_relays_16			= 0x0010,
			USB_OPTOIN_32					= 0x0010,
			USB_relays_32					= 0x0010,
			USB_OPTOIN_32_relays_32			= 0x0011,
			USB_OPTOIN_64					= 0x0011,
			USB_relays_64					= 0x0011,
			USB_TTL_32						= 0x0012,
			USB_TTL_64						= 0x0012,
			
        
        }


        // ----------------------------------------------------------------------------
        // ERROR Codes
        public const uint DAPI_ERR_NONE					= 0;
        public const uint DAPI_ERR_DEVICE_NOT_FOUND		= 0xffffffff;
        public const uint DAPI_ERR_COMMUNICATION_ERROR  = 0xfffffffe;
        public const uint DAPI_ERR_ILLEGAL_HANDLE		= 0xfffffff6;   //-10;
        public const uint DAPI_ERR_FUNCTION_NOT_DEFINED	= 0xfffffff5;   //-11;
        public const uint DAPI_ERR_ILLEGAL_COM_HANDLE	= 0xfffffff4;   //-12;
        public const uint DAPI_ERR_ILLEGAL_MODE			= 0xfffffff3;   //-13;

        // ----------------------------------------------------------------------------
        // Special Function-Codes
        public const uint DAPI_SPECIAL_CMD_GET_MODULE_CONFIG	= 1;
        public const uint DAPI_SPECIAL_CMD_TIMEOUT				= 2;
        public const uint DAPI_SPECIAL_CMD_DI 					= 10;
        public const uint DAPI_SPECIAL_CMD_SET_DIR_DX_1			= 3;
        public const uint DAPI_SPECIAL_CMD_SET_DIR_DX_8			= 4;
        public const uint DAPI_SPECIAL_CMD_GET_MODULE_VERSION	= 5;
        public const uint DAPI_SPECIAL_CMD_DA					= 6;
        public const uint DAPI_SPECIAL_CMD_WATCHDOG             = 7;
        public const uint DAPI_SPECIAL_CMD_COUNTER				= 8;
        public const uint DAPI_SPECIAL_CMD_AD					= 9;
        public const uint DAPI_SPECIAL_CMD_CNT48 				= 11;

        // values for PAR1
        public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_DI			= 1;
        public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_DI_FF		= 7;
        public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_DI_COUNTER = 8;
        public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_DO			= 2;
        public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_DX			= 3;
        public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_AD			= 4;
        public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_DA			= 5;
        public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_TEMP		= 9;
        public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_STEPPER	= 6;
        public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_CNT48		= 10;
		public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_PULSE_GEN 	= 11;
        public const uint DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_PWM_OUT    = 12;
        //
        public const uint DAPI_SPECIAL_GET_MODULE_PAR_VERSION_0		= 0;
        public const uint DAPI_SPECIAL_GET_MODULE_PAR_VERSION_1		= 1;
        public const uint DAPI_SPECIAL_GET_MODULE_PAR_VERSION_2		= 2;
        public const uint DAPI_SPECIAL_GET_MODULE_PAR_VERSION_3		= 3;
        //
        public const uint DAPI_SPECIAL_TIMEOUT_SET_VALUE_SEC		= 1;
        public const uint DAPI_SPECIAL_TIMEOUT_ACTIVATE				= 2;
        public const uint DAPI_SPECIAL_TIMEOUT_DEACTIVATE			= 3;
        public const uint DAPI_SPECIAL_TIMEOUT_GET_STATUS			= 4;
    
        public const uint DAPI_SPECIAL_DI_FF_FILTER_VALUE_SET		= 1;
        public const uint DAPI_SPECIAL_DI_FF_FILTER_VALUE_GET		= 2;
        public const uint DAPI_SPECIAL_AD_READ_MULTIPLE_AD 			= 1;
        public const uint DAPI_SPECIAL_DA_PAR_DA_LOAD_DEFAULT		= 1;
        public const uint DAPI_SPECIAL_DA_PAR_DA_SAVE_EEPROM_CONFIG	= 2;
        public const uint DAPI_SPECIAL_DA_PAR_DA_LOAD_EEPROM_CONFIG	= 3;

        public const uint DAPI_SPECIAL_WATCHDOG_SET_TIMEOUT_MSEC 					= 1;
        public const uint DAPI_SPECIAL_WATCHDOG_GET_TIMEOUT_MSEC 					= 2;
        public const uint DAPI_SPECIAL_WATCHDOG_GET_STATUS 							= 3;
        public const uint DAPI_SPECIAL_WATCHDOG_GET_WD_COUNTER_MSEC 				= 4;
        public const uint DAPI_SPECIAL_WATCHDOG_GET_TIMEOUT_relays_COUNTER_MSEC		= 5;
        public const uint DAPI_SPECIAL_WATCHDOG_SET_TIMEOUT_REL1_COUNTER_MSEC		= 6;
        public const uint DAPI_SPECIAL_WATCHDOG_SET_TIMEOUT_REL2_COUNTER_MSEC		= 7;

        public const uint DAPI_SPECIAL_COUNTER_LATCH_ALL				= 1;
        public const uint DAPI_SPECIAL_COUNTER_LATCH_ALL_WITH_RESET		= 2;
   
        public const uint DAPI_SPECIAL_CNT48_RESET_SINGLE 				= 1;
        public const uint DAPI_SPECIAL_CNT48_RESET_GROUP8 				= 2;
        public const uint DAPI_SPECIAL_CNT48_LATCH_GROUP8 				= 3;
        // ----------------------------------------------------------------------------
        // DapiScanModules-Codes
        public const uint DAPI_SCANMODULE_GET_MODULES_AVAILABLE			= 1;


        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
		// ----------------------------------------------------------------------------
		// ----------------------------------------------------------------------------
		// ----------------------------------------------------------------------------
		// ----------------------------------------------------------------------------
		// ----------------------------------------------------------------------------
        // Prototypes for DELIB-Functions
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------


        // ----------------------------------------------------------------------------
        // 
        [DllImport("DeLib.dll")]
        public static extern uint DapiOpenModule(uint moduleID, uint nr);
        [DllImport("DeLib.dll")]
        public static extern uint DapiOpenModuleEx(uint moduleID, uint nr, [In, Out] DAPI_OPENMODULEEX_STRUCT exbuffer);				
        [DllImport("DeLib.dll")]
        public static extern uint DapiCloseModule(uint handle);

        [DllImport("DeLib.dll")]
        public static extern uint DapiScanModule(uint moduleID, uint cmd);

        [DllImport("DeLib.dll")]
        public static extern uint DapiGetDELIBVersion(uint mode, uint par);

        [DllImport("DeLib.dll")]
        public static extern uint DapiPing(uint handle, uint value);

        // ----------------------------------------------------------------------------
        // Register Access

        [DllImport("DeLib.dll")]
        public static extern void DapiWriteByte(uint handle, uint adress, uint value);
        [DllImport("DeLib.dll")]
        public static extern void DapiWriteWord(uint handle, uint adress, uint value);
        [DllImport("DeLib.dll")]
        public static extern void DapiWriteLong(uint handle, uint adress, uint value);
        [DllImport("DeLib.dll")]
        public static extern void DapiWriteLongLong(uint handle, uint adress, UInt64 value);

        [DllImport("DeLib.dll")]
        public static extern uint DapiReadByte(uint handle, uint adress);
        [DllImport("DeLib.dll")]
        public static extern uint DapiReadWord(uint handle, uint adress);
        [DllImport("DeLib.dll")]
        public static extern uint DapiReadLong(uint handle, uint adress);
        [DllImport("DeLib.dll")]
        public static extern UInt64 DapiReadLongLong(uint handle, uint adress);

        [DllImport("DeLib.dll")]
        public static extern void DapiWriteSetByte(uint handle, uint adress, uint value);
        [DllImport("DeLib.dll")]
        public static extern void DapiWriteClearByte(uint handle, uint adress, uint value);

        // ----------------------------------------------------------------------------
        // Error Handling

        [DllImport("DeLib.dll")]
        public static extern uint DapiGetLastError();
        [DllImport("DeLib.dll")]
        public static extern uint DapiGetLastErrorText(StringBuilder msg, uint msg_length);
        [DllImport("DeLib.dll")]
		public static extern void DapiClearLastError();

        // ----------------------------------------------------------------------------
        // Digital Inputs
        [DllImport("DeLib.dll")]
        public static extern uint DapiDIGet1(uint handle, uint ch);
        [DllImport("DeLib.dll")]
        public static extern uint DapiDIGet8(uint handle, uint ch);
        [DllImport("DeLib.dll")]
        public static extern uint DapiDIGet16(uint handle, uint ch);
        [DllImport("DeLib.dll")]
        public static extern uint DapiDIGet32(uint handle, uint ch);
        [DllImport("DeLib.dll")]
        public static extern UInt64 DapiDIGet64(uint handle, uint ch);

        [DllImport("DeLib.dll")]
        public static extern uint DapiDIGetFF32(uint handle, uint ch);

        [DllImport("DeLib.dll")]
        public static extern uint DapiDIGetCounter(uint handle, uint ch, uint mode);


        // ----------------------------------------------------------------------------
        // Digital Outputs
        [DllImport("DeLib.dll")]
        public static extern void DapiDOSet1(uint handle, uint ch, uint data);
        [DllImport("DeLib.dll")]
        public static extern void DapiDOSet8(uint handle, uint ch, uint data);
        [DllImport("DeLib.dll")]
        public static extern void DapiDOSet16(uint handle, uint ch, uint data);
        [DllImport("DeLib.dll")]
        public static extern void DapiDOSet32(uint handle, uint ch, uint data);
        [DllImport("DeLib.dll")]
        public static extern void DapiDOSet64(uint handle, uint ch, UInt64 data);

        [DllImport("DeLib.dll")]
        public static extern uint DapiDOReadback32(uint handle, uint ch);
        [DllImport("DeLib.dll")]
        public static extern UInt64 DapiDOReadback64(uint handle, uint ch);

        [DllImport("DeLib.dll")]
        public static extern void DapiDOSet1_WithTimer(uint handle, uint ch, uint data, uint time_ms);

        // ----------------------------------------------------------------------------
        // Analog Inputs
        [DllImport("DeLib.dll")]
        public static extern uint DapiADGet(uint handle, uint ch);
        [DllImport("DeLib.dll")]
        public static extern float DapiADGetVolt(uint handle, uint ch);
        [DllImport("DeLib.dll")]
        public static extern float DapiADGetmA(uint handle, uint ch);
        [DllImport("DeLib.dll")]
        public static extern void DapiADSetMode(uint handle, uint ch, uint mode);
        [DllImport("DeLib.dll")]
        public static extern uint DapiADGetMode(uint handle, uint ch);

        // ----------------------------------------------------------------------------
        // Analog Outputs
        [DllImport("DeLib.dll")]
        public static extern void DapiDASet(uint handle, uint ch, uint data);
        [DllImport("DeLib.dll")]
        public static extern void DapiDASetVolt(uint handle, uint ch, float data);
        [DllImport("DeLib.dll")]
        public static extern void DapiDASetmA(uint handle, uint ch, float data);
        [DllImport("DeLib.dll")]
        public static extern void DapiDASetMode(uint handle, uint ch, uint mode);
        [DllImport("DeLib.dll")]
		public static extern uint DapiDAGetMode(uint handle, uint ch);
		
		// ----------------------------------------------------------------------------
		// Temperature Inputs
		[DllImport("DeLib.dll")]
        public static extern float DapiTempGet(uint handle, uint ch);
		
		// ----------------------------------------------------------------------------
		// Counter48 Inputs
		[DllImport("DeLib.dll")]		
		public static extern void DapiCnt48ModeSet(uint handle, uint ch, uint mode);
		[DllImport("DeLib.dll")]
		public static extern uint DapiCnt48ModeGet(uint handle, uint ch);
		[DllImport("DeLib.dll")]
		public static extern uint DapiCnt48CounterGet32(uint handle, uint ch);
		[DllImport("DeLib.dll")]
		public static extern UInt64 DapiCnt48CounterGet48(uint handle, uint ch);

		// ----------------------------------------------------------------------------
		// Pulse-Generator Outputs
		[DllImport("DeLib.dll")]
		public static extern void DapiPulseGenSet(uint handle, uint ch, uint mode, uint par0, uint par1, uint par2);

        // ----------------------------------------------------------------------------
        // PWM Outputs
        [DllImport("DeLib.dll")]
        public static extern void DapiPWMOutSet(uint handle, uint ch, float data);

		// ----------------------------------------------------------------------------
        // Stepper
        [DllImport("DeLib.dll")]
        public static extern uint DapiStepperCommand(uint handle, uint motor, uint cmd, uint par1, uint par2, uint par3, uint par4);
        [DllImport("DeLib.dll")]
        public static extern uint DapiStepperCommandEx(uint handle, uint motor, uint cmd, uint par1, uint par2, uint par3, uint par4, uint par5, uint par6, uint par7);
        [DllImport("DeLib.dll")]
        public static extern uint DapiStepperGetStatus(uint handle, uint motor, uint cmd);

        // ----------------------------------------------------------------------------
        // Watchdog
        [DllImport("DeLib.dll")]
        public static extern void DapiWatchdogEnable(uint handle);
        [DllImport("DeLib.dll")]
        public static extern void DapiWatchdogDisable(uint handle);
        [DllImport("DeLib.dll")]
        public static extern void DapiWatchdogRetrigger(uint handle);

        // ----------------------------------------------------------------------------
        // CAN
       	[StructLayout(LayoutKind.Sequential)]
    	public class DAPI_CAN_MESSAGE_STRUCT
        {
            public uint address;
        	public uint timestamp;
        	public uint use_extended_ids;
        	public uint data_count;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
            public string data;
        };

        [DllImport("DeLib.dll")]
        public static extern uint DapiCANCommand(uint handle, uint cmd, uint par1, uint par2, uint par3);
        [DllImport("DeLib.dll")]
        public static extern uint DapiCANGetPacket(uint handle, uint message_box_nr, [In, Out] DAPI_CAN_MESSAGE_STRUCT can_msg);
        [DllImport("DeLib.dll")]
        public static extern void DapiCANSendPacket(uint handle, [In, Out] DAPI_CAN_MESSAGE_STRUCT can_msg);


        // ----------------------------------------------------------------------------
        // Special
        [DllImport("DeLib.dll")]
        public static extern uint DapiSpecialCommand(uint handle, uint cmd, uint par1, uint par2, uint par3);

        [DllImport("DeLib.dll")]
        public static extern uint DapiReadMultipleBytes(uint handle, uint adress, uint adress_depth, uint increments, [MarshalAs(UnmanagedType.LPStr)]String buff, uint buff_len);
        [DllImport("DeLib.dll")]
        public static extern uint DapiWriteMultipleBytes(uint handle, uint adress, uint adress_depth, uint increments, [MarshalAs(UnmanagedType.LPStr)]String buff, uint buff_len);

        // ----------------------------------------------------------------------------



        // ----------------------------------------------------------------------------
        // DI - Counter Mode

        public const uint DAPI_CNT_MODE_READ_WITH_RESET	= 0x01;
		public const uint DAPI_CNT_MODE_READ_LATCHED	= 0x02;

        // ----------------------------------------------------------------------------
        // A/D and D/A Modes

        public const uint ADDA_MODE_UNIPOL_10V		= 0x00;
        public const uint ADDA_MODE_UNIPOL_5V		= 0x01;
        public const uint ADDA_MODE_UNIPOL_2V5		= 0x02;
    
        public const uint ADDA_MODE_BIPOL_10V		= 0x40;
        public const uint ADDA_MODE_BIPOL_5V		= 0x41;
        public const uint ADDA_MODE_BIPOL_2V5		= 0x42;

        public const uint ADDA_MODE_0_20mA			= 0x80;
        public const uint ADDA_MODE_4_20mA			= 0x81;
        public const uint ADDA_MODE_0_24mA			= 0x82;
        //public const uint ADDA_MODE_0_25mA		= 0x83;
        public const uint ADDA_MODE_0_50mA			= 0x84;


        public const uint ADDA_MODE_DA_DISABLE		= 0x100;
        public const uint ADDA_MODE_DA_ENABLE		= 0x200;

        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // Stepper-Defines

        // ------------------------------------
        // ERROR Codes

        public const uint DAPI_STEPPER_ERR_NONE				=0;				// es liegt kein Fehler vor 
        public const uint DAPI_STEPPER_ERR_PARAMETER		=1;				// Parameter hat falschen Wertebereich 
        public const uint DAPI_STEPPER_ERR_MOTOR_MOVE		=2;				// Kommando abgelehnt, da sich der Motor dreht
        public const uint DAPI_STEPPER_ERR_DISABLE_MOVE		=3;				// Kommando abgehelnt, da Motorbewegung disabled ist
        public const uint DAPI_STEPPER_ERR_DEVICE_NOT_FOUND	=0xffffffff;	// es liegt kein Fehler vor 

        // ------------------------------------
        // Special Stepper Function-Codes

        public const uint DAPI_STEPPER_RETURN_0_BYTES =0x00000000;						// Kommando schickt 0 Byte als Antwort
        public const uint DAPI_STEPPER_RETURN_1_BYTES =0x40000000;						// Kommando schickt 1 Byte als Antwort
        public const uint DAPI_STEPPER_RETURN_2_BYTES =0x80000000;						// Kommando schickt 2 Byte als Antwort
        public const uint DAPI_STEPPER_RETURN_4_BYTES =0xc0000000;						// Kommando schickt 4 Byte als Antwort
   

        public const uint DAPI_STEPPER_CMD_SET_MOTORCHARACTERISTIC                = ( 0x00000001 + DAPI_STEPPER_RETURN_0_BYTES );
        public const uint DAPI_STEPPER_CMD_GET_MOTORCHARACTERISTIC                = ( 0x00000002 + DAPI_STEPPER_RETURN_4_BYTES ); 
        public const uint DAPI_STEPPER_CMD_SET_POSITION                           = ( 0x00000003 + DAPI_STEPPER_RETURN_0_BYTES );  
        public const uint DAPI_STEPPER_CMD_GO_POSITION                            = ( 0x00000004 + DAPI_STEPPER_RETURN_0_BYTES );  
        public const uint DAPI_STEPPER_CMD_GET_POSITION                           = ( 0x00000005 + DAPI_STEPPER_RETURN_4_BYTES );  
        public const uint DAPI_STEPPER_CMD_SET_FREQUENCY                          = ( 0x00000006 + DAPI_STEPPER_RETURN_0_BYTES );  
        public const uint DAPI_STEPPER_CMD_SET_FREQUENCY_DIRECTLY                 = ( 0x00000007 + DAPI_STEPPER_RETURN_0_BYTES );  
        public const uint DAPI_STEPPER_CMD_GET_FREQUENCY                          = ( 0x00000008 + DAPI_STEPPER_RETURN_2_BYTES );  
        public const uint DAPI_STEPPER_CMD_FULLSTOP                               = ( 0x00000009 + DAPI_STEPPER_RETURN_0_BYTES );  
        public const uint DAPI_STEPPER_CMD_STOP                                   = ( 0x00000010 + DAPI_STEPPER_RETURN_0_BYTES );  
        public const uint DAPI_STEPPER_CMD_GO_REFSWITCH                           = ( 0x00000011 + DAPI_STEPPER_RETURN_0_BYTES );  
        public const uint DAPI_STEPPER_CMD_DISABLE                                = ( 0x00000014 + DAPI_STEPPER_RETURN_0_BYTES );  
        public const uint DAPI_STEPPER_CMD_MOTORCHARACTERISTIC_LOAD_DEFAULT		  = ( 0x00000015 + DAPI_STEPPER_RETURN_0_BYTES );
        public const uint DAPI_STEPPER_CMD_MOTORCHARACTERISTIC_EEPROM_SAVE		  = ( 0x00000016 + DAPI_STEPPER_RETURN_0_BYTES );
        public const uint DAPI_STEPPER_CMD_MOTORCHARACTERISTIC_EEPROM_LOAD		  = ( 0x00000017 + DAPI_STEPPER_RETURN_0_BYTES );
        public const uint DAPI_STEPPER_CMD_GET_CPU_TEMP							  = ( 0x00000018 + DAPI_STEPPER_RETURN_1_BYTES );
        public const uint DAPI_STEPPER_CMD_GET_MOTOR_SUPPLY_VOLTAGE				  = ( 0x00000019 + DAPI_STEPPER_RETURN_2_BYTES );
        public const uint DAPI_STEPPER_CMD_GO_POSITION_RELATIVE				      = ( 0x00000020 + DAPI_STEPPER_RETURN_0_BYTES );
        public const uint DAPI_STEPPER_CMD_EEPROM_ERASE							  = ( 0x00000021 + DAPI_STEPPER_RETURN_0_BYTES );
        public const uint DAPI_STEPPER_CMD_SET_VECTORMODE                         = ( 0x00000040 + DAPI_STEPPER_RETURN_0_BYTES );  

        //public const uint DAPI_STEPPER_CMD_GET_STATUS                             = ( 0x00000015 + DAPI_STEPPER_RETURN_1_BYTES );


        // ------------------------------------
        // values for PAR1 for DAPI_STEPPER_CMD_SET_MOTORCHARACTERISTIC

        public const uint DAPI_STEPPER_MOTORCHAR_PAR_STEPMODE								= 1;	// Schrittmode (Voll-, Halb-, Viertel-, Achtel-, Sechszehntelschritt 
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_GOFREQUENCY							= 2;	// Schrittfrequenz bei GoPosition [Vollschritt / s]
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_STARTFREQUENCY		    				= 3;	// Startfrequenz [Vollschritt / s]
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_STOPFREQUENCY		    				= 4;	// Stopfrequenz [Vollschritt / s]
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_MAXFREQUENCY							= 5;	// maximale Frequenz [Vollschritt / s]
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_ACCELERATIONSLOPE	    				= 6;	// Beschleunigung in [Vollschritten / ms]
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_DECELERATIONSLOPE	    				= 7;  	// Bremsung in [Vollschritten / ms]
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_PHASECURRENT							= 8;	// Phasenstrom [mA]
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_HOLDPHASECURRENT						= 9;	// Phasenstrom bei Motorstillstand [mA]
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_HOLDTIME 			    				= 10;	// Zeit in der der Haltestrom fließt nach Motorstop [s]
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_STATUSLEDMODE		    				= 11;	// Betriebsart der Status-LED
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_INVERT_ENDSW1		    				= 12;	// invertiere Funktion des Endschalter1  
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_INVERT_ENDSW2		    				= 13;	// invertiere Funktion des Endschalter12 
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_INVERT_REFSW1		    				= 14;	// invertiere Funktion des Referenzschalterschalter1
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_INVERT_REFSW2		    				= 15;	// invertiere Funktion des Referenzschalterschalter2
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_INVERT_DIRECTION 	    				= 16;	// invertiere alle Richtungsangaben
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_ENDSWITCH_STOPMODE	    				= 17;	// Bei Endschalter soll (0=full stop/1=stop mit rampe)
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_GOREFERENCEFREQUENCY_TOENDSWITCH	    = 18;	// Motor Frequency for GoReferenceCommand
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_GOREFERENCEFREQUENCY_AFTERENDSWITCH	= 19;	// Motor Frequency for GoReferenceCommand
        public const uint DAPI_STEPPER_MOTORCHAR_PAR_GOREFERENCEFREQUENCY_TOOFFSET	        = 20;	// Motor Frequency for GoReferenceCommand

        // ----------------------------------------------------------------------------
        // values for PAR1 for DAPI_STEPPER_CMD_GO_REFSWITCH

        public const uint DAPI_STEPPER_GO_REFSWITCH_PAR_REF1				= 1;
        public const uint DAPI_STEPPER_GO_REFSWITCH_PAR_REF2				= 2;
        public const uint DAPI_STEPPER_GO_REFSWITCH_PAR_REF_LEFT			= 4;
        public const uint DAPI_STEPPER_GO_REFSWITCH_PAR_REF_RIGHT			= 8;
        public const uint DAPI_STEPPER_GO_REFSWITCH_PAR_REF_GO_POSITIVE	    = 16;
        public const uint DAPI_STEPPER_GO_REFSWITCH_PAR_REF_GO_NEGATIVE	    = 32;
        public const uint DAPI_STEPPER_GO_REFSWITCH_PAR_SET_POS_0			= 64;

        // ------------------------------------
        // Stepper Read Status
        public const uint DAPI_STEPPER_STATUS_GET_POSITION				    = 0x01;
        public const uint DAPI_STEPPER_STATUS_GET_SWITCH					= 0x02;
        public const uint DAPI_STEPPER_STATUS_GET_ACTIVITY				    = 0x03;



        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // CAN-Defines



        // ------------------------------------
        // CAN Commands

        public const uint DAPI_CAN_CMD_SET_BITRATE		= 1;
        public const uint DAPI_CAN_CMD_SET_MASK0		= 2;
        public const uint DAPI_CAN_CMD_SET_RX_ADDRESS	= 3;
        public const uint DAPI_CAN_CMD_CLR_TIMESTAMP	= 4;

        public const uint DAPI_CAN_CMD_TEST_GEN_RX_PACK	= 0xfffffff0;


        public const uint DAPI_PAR_CAN_MESSAGE_BOX_0	= 0;
        public const uint DAPI_PAR_CAN_MESSAGE_BOX_1	= 1;
        public const uint DAPI_PAR_CAN_MESSAGE_BOX_2	= 2;
        public const uint DAPI_PAR_CAN_MESSAGE_BOX_3	= 3;

        public const uint DAPI_CAN_BITRATE_10000		= 10000;
        public const uint DAPI_CAN_BITRATE_20000		= 20000;
        public const uint DAPI_CAN_BITRATE_50000		= 50000;
        public const uint DAPI_CAN_BITRATE_100000		= 100000;
        public const uint DAPI_CAN_BITRATE_125000		= 125000;
        public const uint DAPI_CAN_BITRATE_250000		= 250000;
        public const uint DAPI_CAN_BITRATE_500000		= 500000;
        public const uint DAPI_CAN_BITRATE_1000000  	= 1000000;

        public const uint DAPI_CAN_MASK_SINGLE			= 0xffffffff;
        public const uint DAPI_CAN_MASK_ALL				= 0x0;

		// ----------------------------------------------------------------------------
		// ----------------------------------------------------------------------------
		// ----------------------------------------------------------------------------
		// ----------------------------------------------------------------------------
		// ----------------------------------------------------------------------------
		// CNT48 Commands


		public const uint DAPI_CNT48_FILTER_20ns		= 0x0000;
		public const uint DAPI_CNT48_FILTER_100ns		= 0x1000;
   		public const uint DAPI_CNT48_FILTER_250ns		= 0x2000;
		public const uint DAPI_CNT48_FILTER_500ns		= 0x3000;
   		public const uint DAPI_CNT48_FILTER_1us			= 0x4000;
		public const uint DAPI_CNT48_FILTER_2_5us		= 0x5000;
		public const uint DAPI_CNT48_FILTER_5us			= 0x6000;
		public const uint DAPI_CNT48_FILTER_10us		= 0x7000;
		public const uint DAPI_CNT48_FILTER_25us		= 0x8000;
		public const uint DAPI_CNT48_FILTER_50us		= 0x9000;
		public const uint DAPI_CNT48_FILTER_100us		= 0xA000;
		public const uint DAPI_CNT48_FILTER_250us		= 0xB000;
		public const uint DAPI_CNT48_FILTER_500us		= 0xC000;
		public const uint DAPI_CNT48_FILTER_1ms			= 0xD000;
		public const uint DAPI_CNT48_FILTER_2_5ms		= 0xE000;
		public const uint DAPI_CNT48_FILTER_5ms			= 0xF000;
		
		public const uint DAPI_CNT48_MODE_COUNT_RISING_EDGE					= 0x0000;
		public const uint DAPI_CNT48_MODE_T									= 0x000D;
		public const uint DAPI_CNT48_MODE_FREQUENCY							= 0x000E;
		public const uint DAPI_CNT48_MODE_PWM								= 0x000F;

		public const uint DAPI_CNT48_SUBMODE_NO_RESET 						= 0x0000;
		public const uint DAPI_CNT48_SUBMODE_RESET_WITH_READ				= 0x0010;
		public const uint DAPI_CNT48_SUBMODE_RESET_ON_CH_7					= 0x0070;
		public const uint DAPI_CNT48_SUBMODE_LATCH_COMMON					= 0x0080;
		// ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // ----------------------------------------------------------------------------
        // Structs
		
       	[StructLayout(LayoutKind.Sequential)]
    	public class DAPI_OPENMODULEEX_STRUCT
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string address;
            public uint portno;
        };
    }
}

