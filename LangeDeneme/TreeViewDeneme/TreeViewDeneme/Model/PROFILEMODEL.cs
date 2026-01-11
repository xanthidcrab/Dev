using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_Base;
namespace TreeViewDeneme.Model
{
    public class PROFILEMODEL : ObserrvableObject
    {
        private string _stockCode;
        public string STOCKCODE
        {
            get => _stockCode;
            set => SetProperty(ref _stockCode, value);
        }

        private string _profileName;
        public string PROFILENAME
        {
            get => _profileName;
            set => SetProperty(ref _profileName, value);
        }

        private string _profileBrand;
        public string PROFILEBRAND
        {
            get => _profileBrand;
            set => SetProperty(ref _profileBrand, value);
        }

        private double _profileBeadChannelX;
        public double PROFILEBEADCHANNELX
        {
            get => _profileBeadChannelX;
            set => SetProperty(ref _profileBeadChannelX, value);
        }

        private double _profileBeadChannelY;
        public double PROFILEBEADCHANNELY
        {
            get => _profileBeadChannelY;
            set => SetProperty(ref _profileBeadChannelY, value);
        }

        private double _profilSizeX;
        public double PROFILSIZEX
        {
            get => _profilSizeX;
            set => SetProperty(ref _profilSizeX, value);
        }

        private double _profilSizeY;
        public double PROFILSIZEY
        {
            get => _profilSizeY;
            set => SetProperty(ref _profilSizeY, value);
        }

        private double _liftPointX;
        public double LIFTPOINTX
        {
            get => _liftPointX;
            set => SetProperty(ref _liftPointX, value);
        }

        private double _liftPointY;
        public double LIFTPOINTY
        {
            get => _liftPointY;
            set => SetProperty(ref _liftPointY, value);
        }

        private double _supportPointX;
        public double SUPPORTPOINTX
        {
            get => _supportPointX;
            set => SetProperty(ref _supportPointX, value);
        }

        private double _supportPointY;
        public double SUPPORTPOINTY
        {
            get => _supportPointY;
            set => SetProperty(ref _supportPointY, value);
        }

        private double _gripperCatchX;
        public double GRIPPERCATCHX
        {
            get => _gripperCatchX;
            set => SetProperty(ref _gripperCatchX, value);
        }

        private double _gripperCatchY;
        public double GRIPPERCATCHY
        {
            get => _gripperCatchY;
            set => SetProperty(ref _gripperCatchY, value);
        }

        private double _gripperAngle;
        public double GRIPPERANGLE
        {
            get => _gripperAngle;
            set => SetProperty(ref _gripperAngle, value);
        }

        private string _profileType;
        public string PROFILETYPE
        {
            get => _profileType;
            set => SetProperty(ref _profileType, value);
        }

        private string _rawMaterial;
        public string RAWMATERIAL
        {
            get => _rawMaterial;
            set => SetProperty(ref _rawMaterial, value);
        }

        private string _gasketClamp;
        public string GASKETCLAMP
        {
            get => _gasketClamp;
            set => SetProperty(ref _gasketClamp, value);
        }

        private string _option1;
        public string OPTION1
        {
            get => _option1;
            set => SetProperty(ref _option1, value);
        }

        private string _option2;
        public string OPTION2
        {
            get => _option2;
            set => SetProperty(ref _option2, value);
        }

        private string _option3;
        public string OPTION3
        {
            get => _option3;
            set => SetProperty(ref _option3, value);
        }

        private string _option4;
        public string OPTION4
        {
            get => _option4;
            set => SetProperty(ref _option4, value);
        }

        private string _option5;
        public string OPTION5
        {
            get => _option5;
            set => SetProperty(ref _option5, value);
        }

        private double _heightOffset;
        public double HEIGHTOFFSET
        {
            get => _heightOffset;
            set => SetProperty(ref _heightOffset, value);
        }

        private double _widthOffset;
        public double WIDTHOFFSET
        {
            get => _widthOffset;
            set => SetProperty(ref _widthOffset, value);
        }

        private int _saw;
        public int SAW
        {
            get => _saw;
            set => SetProperty(ref _saw, value);
        }

        private int _cutSpeed;
        public int CUTSPEED
        {
            get => _cutSpeed;
            set => SetProperty(ref _cutSpeed, value);
        }

        private int _beltReverse;
        public int BELTREVERSE
        {
            get => _beltReverse;
            set => SetProperty(ref _beltReverse, value);
        }

        private double _gripperDescend;
        public double GRIPPERDESCEND
        {
            get => _gripperDescend;
            set => SetProperty(ref _gripperDescend, value);
        }

        private string _optionParam1;
        public string OPTIONPARAM1
        {
            get => _optionParam1;
            set => SetProperty(ref _optionParam1, value);
        }

        private string _optionParam2;
        public string OPTIONPARAM2
        {
            get => _optionParam2;
            set => SetProperty(ref _optionParam2, value);
        }

        private string _optionParam3;
        public string OPTIONPARAM3
        {
            get => _optionParam3;
            set => SetProperty(ref _optionParam3, value);
        }

        private string _optionParam4;
        public string OPTIONPARAM4
        {
            get => _optionParam4;
            set => SetProperty(ref _optionParam4, value);
        }

        private string _optionParam5;
        public string OPTIONPARAM5
        {
            get => _optionParam5;
            set => SetProperty(ref _optionParam5, value);
        }

        private string _optionParam6;
        public string OPTIONPARAM6
        {
            get => _optionParam6;
            set => SetProperty(ref _optionParam6, value);
        }

        private string _optionParam7;
        public string OPTIONPARAM7
        {
            get => _optionParam7;
            set => SetProperty(ref _optionParam7, value);
        }

        private string _optionParam8;
        public string OPTIONPARAM8
        {
            get => _optionParam8;
            set => SetProperty(ref _optionParam8, value);
        }

        private string _optionParam9;
        public string OPTIONPARAM9
        {
            get => _optionParam9;
            set => SetProperty(ref _optionParam9, value);
        }

        private string _optionParam10;
        public string OPTIONPARAM10
        {
            get => _optionParam10;
            set => SetProperty(ref _optionParam10, value);
        }

        private double _vClampPosBackX;
        public double VCLAMPPOS_BACK_X
        {
            get => _vClampPosBackX;
            set => SetProperty(ref _vClampPosBackX, value);
        }

        private double _vClampPosBackY;
        public double VCLAMPPOS_BACK_Y
        {
            get => _vClampPosBackY;
            set => SetProperty(ref _vClampPosBackY, value);
        }

        private double _vClampPosFrontX;
        public double VCLAMPPOS_FRONT_X
        {
            get => _vClampPosFrontX;
            set => SetProperty(ref _vClampPosFrontX, value);
        }

        private double _vClampPosFrontY;
        public double VCLAMPPOS_FRONT_Y
        {
            get => _vClampPosFrontY;
            set => SetProperty(ref _vClampPosFrontY, value);
        }

        private double _hClampPosX;
        public double HCLAMPPOS_X
        {
            get => _hClampPosX;
            set => SetProperty(ref _hClampPosX, value);
        }

        private double _hClampPosY;
        public double HCLAMPPOS_Y
        {
            get => _hClampPosY;
            set => SetProperty(ref _hClampPosY, value);
        }

        private double _verticalAlMeasureY;
        public double VERTICALALMEASUREY
        {
            get => _verticalAlMeasureY;
            set => SetProperty(ref _verticalAlMeasureY, value);
        }

        private double   _horizontalMeasureX;
        public double HORIZONTALMEASUREX
        {
            get => _horizontalMeasureX;
            set => SetProperty(ref _horizontalMeasureX, value);
        }

        private string _operations;
        public string OPERATIONS
        {
            get => _operations;
            set => SetProperty(ref _operations, value);
        }

        private int _id;
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
    }
}
