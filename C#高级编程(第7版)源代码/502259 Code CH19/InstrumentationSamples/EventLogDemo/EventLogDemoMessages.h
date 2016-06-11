 // EventLogDemoMessages.mc
 // ********************************************************
 // - Event categories -
 // Categories must be numbered consecutively starting at 1.
 // ********************************************************
//
//  Values are 32 bit values layed out as follows:
//
//   3 3 2 2 2 2 2 2 2 2 2 2 1 1 1 1 1 1 1 1 1 1
//   1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0
//  +---+-+-+-----------------------+-------------------------------+
//  |Sev|C|R|     Facility          |               Code            |
//  +---+-+-+-----------------------+-------------------------------+
//
//  where
//
//      Sev - is the severity code
//
//          00 - Success
//          01 - Informational
//          10 - Warning
//          11 - Error
//
//      C - is the Customer code flag
//
//      R - is a reserved bit
//
//      Facility - is the facility code
//
//      Code - is the facility's status code
//
//
// Define the facility codes
//


//
// Define the severity codes
//


//
// MessageId: INSTALL_CATEGORY
//
// MessageText:
//
//  Installation
//
#define INSTALL_CATEGORY                 0x00000001L

//
// MessageId: DATA_CATEGORY
//
// MessageText:
//
//  Database Query
//
#define DATA_CATEGORY                    0x00000002L

//
// MessageId: UPDATE_CATEGORY
//
// MessageText:
//
//  Data Update
//
#define UPDATE_CATEGORY                  0x00000003L

//
// MessageId: NETWORK_CATEGORY
//
// MessageText:
//
//  Network Communication
//
#define NETWORK_CATEGORY                 0x00000004L

 // - Event messages -
 // *********************************
//
// MessageId: MSG_CONNECT_1000
//
// MessageText:
//
//  Connection successful.
//
#define MSG_CONNECT_1000                 0x000003E8L

//
// MessageId: MSG_CONNECT_FAILED_1001
//
// MessageText:
//
//  Could not connect to server %1.
//
#define MSG_CONNECT_FAILED_1001          0xC00003E9L

//
// MessageId: MSG_DB_UPDATE_1002
//
// MessageText:
//
//  Database update failed.
//
#define MSG_DB_UPDATE_1002               0xC00003EAL

//
// MessageId: APP_UPDATE
//
// MessageText:
//
//  Application %%5002 updated.
//
#define APP_UPDATE                       0x000003EBL

 // - Event log display name -
 // ********************************************************
//
// MessageId: EVENT_LOG_DISPLAY_NAME_MSGID
//
// MessageText:
//
//  Professional C# Sample Event Log
//
#define EVENT_LOG_DISPLAY_NAME_MSGID     0x00001389L

 // - Event message parameters -
 //   Language independent insertion strings
 // ********************************************************
//
// MessageId: EVENT_LOG_SERVICE_NAME_MSGID
//
// MessageText:
//
//  EventLogDemo.EXE
//
#define EVENT_LOG_SERVICE_NAME_MSGID     0x0000138AL

