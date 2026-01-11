using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_Base;
namespace TreeViewDeneme.Model
{
    public class OPERATIONMODEL : ObserrvableObject
    {
        private int _id;
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private int _operationCode;
        public int OPERATIONCODE
        {
            get => _operationCode;
            set => SetProperty(ref _operationCode, value);
        }

        private int _operationType;
        public int OPERATIONTYPE
        {
            get => _operationType;
            set => SetProperty(ref _operationType, value);
        }

        private int _originalOperationType;
        public int ORIGINALOPERATIONTYPE
        {
            get => _originalOperationType;
            set => SetProperty(ref _originalOperationType, value);
        }

        private int _toolNm;
        public int TOOLNM
        {
            get => _toolNm;
            set => SetProperty(ref _toolNm, value);
        }

        private double _xPos;
        public double XPOS
        {
            get => _xPos;
            set => SetProperty(ref _xPos, value);
        }

        private double _yPos;
        public double YPOS
        {
            get => _yPos;
            set => SetProperty(ref _yPos, value);
        }

        private double _zPos;
        public double ZPOS
        {
            get => _zPos;
            set => SetProperty(ref _zPos, value);
        }

        private double _approachDist;
        public double APPROACHDIST
        {
            get => _approachDist;
            set => SetProperty(ref _approachDist, value);
        }

        private double _depth;
        public double DEPTH
        {
            get => _depth;
            set => SetProperty(ref _depth, value);
        }

        private double _a;
        public double A
        {
            get => _a;
            set => SetProperty(ref _a, value);
        }

        private double _b;
        public double B
        {
            get => _b;
            set => SetProperty(ref _b, value);
        }

        private double _c;
        public double C
        {
            get => _c;
            set => SetProperty(ref _c, value);
        }

        private double _d;
        public double D
        {
            get => _d;
            set => SetProperty(ref _d, value);
        }

        private double _e;
        public double E
        {
            get => _e;
            set => SetProperty(ref _e, value);
        }

        private double _xOffset;
        public double XOFFSET
        {
            get => _xOffset;
            set => SetProperty(ref _xOffset, value);
        }

        private double _yOffset;
        public double YOFFSET
        {
            get => _yOffset;
            set => SetProperty(ref _yOffset, value);
        }

        private double _zOffset;
        public double ZOFFSET
        {
            get => _zOffset;
            set => SetProperty(ref _zOffset, value);
        }

        private double _idleSpd;
        public double IDLESPD
        {
            get => _idleSpd;
            set => SetProperty(ref _idleSpd, value);
        }

        private double _penetrateSpd;
        public double PENETRATESPD
        {
            get => _penetrateSpd;
            set => SetProperty(ref _penetrateSpd, value);
        }

        private double _millFeedSpd;
        public double MILLFEEDSPD
        {
            get => _millFeedSpd;
            set => SetProperty(ref _millFeedSpd, value);
        }

        private double _circleSpd;
        public double CIRCLESPD
        {
            get => _circleSpd;
            set => SetProperty(ref _circleSpd, value);
        }

        private double _jumpSpd;
        public double JUMPSPD
        {
            get => _jumpSpd;
            set => SetProperty(ref _jumpSpd, value);
        }

        private double _rpm;
        public double RPM
        {
            get => _rpm;
            set => SetProperty(ref _rpm, value);
        }

        private int _hierarchy;
        public int HIERARCHY
        {
            get => _hierarchy;
            set => SetProperty(ref _hierarchy, value);
        }

        private string _operationName;
        public string OPERATIONNAME
        {
            get => _operationName;
            set => SetProperty(ref _operationName, value);
        }

        private int _opGroup;
        public int OPGROUP
        {
            get => _opGroup;
            set => SetProperty(ref _opGroup, value);
        }

        private int _pieceId;
        public int PIECEID
        {
            get => _pieceId;
            set => SetProperty(ref _pieceId, value);
        }

        private double _angle;
        public double ANGLE
        {
            get => _angle;
            set => SetProperty(ref _angle, value);
        }

        private double _r1;
        public double R1
        {
            get => _r1;
            set => SetProperty(ref _r1, value);
        }

        private double _r2;
        public double R2
        {
            get => _r2;
            set => SetProperty(ref _r2, value);
        }

        private double _r3;
        public double R3
        {
            get => _r3;
            set => SetProperty(ref _r3, value);
        }

        private double _r4;
        public double R4
        {
            get => _r4;
            set => SetProperty(ref _r4, value);
        }

        private double _r5;
        public double R5
        {
            get => _r5;
            set => SetProperty(ref _r5, value);
        }

        private double _r6;
        public double R6
        {
            get => _r6;
            set => SetProperty(ref _r6, value);
        }

        private int _cw;
        public int CW
        {
            get => _cw;
            set => SetProperty(ref _cw, value);
        }

        private string _depthTable;
        public string DEPTHTABLE
        {
            get => _depthTable;
            set => SetProperty(ref _depthTable, value);
        }

        private int _priority;
        public int PRIORITY
        {
            get => _priority;
            set => SetProperty(ref _priority, value);
        }

        private int _groupNm;
        public int GROUPNM
        {
            get => _groupNm;
            set => SetProperty(ref _groupNm, value);
        }

        private int _jumpStep;
        public int JUMPSTEP
        {
            get => _jumpStep;
            set => SetProperty(ref _jumpStep, value);
        }

        private int _drawStroke;
        public int DRAWSTROKE
        {
            get => _drawStroke;
            set => SetProperty(ref _drawStroke, value);
        }

        private string _ownerProfileCode;
        public string OWNERPROFILECODE
        {
            get => _ownerProfileCode;
            set => SetProperty(ref _ownerProfileCode, value);
        }

        private int _depthLevelNumber;
        public int DEPTHLEVELNUMBER
        {
            get => _depthLevelNumber;
            set => SetProperty(ref _depthLevelNumber, value);
        }

        private int _zeroDepthLevelTool;
        public int ZERODEPTHLEVELTOOL
        {
            get => _zeroDepthLevelTool;
            set => SetProperty(ref _zeroDepthLevelTool, value);
        }

        private string _operationsDataTableId;
        public string OPERATIONSDATATABLE_Id
        {
            get => _operationsDataTableId;
            set => SetProperty(ref _operationsDataTableId, value);
        }

        private int _localId;
        public int LOCALID
        {
            get => _localId;
            set => SetProperty(ref _localId, value);
        }
    }
}
