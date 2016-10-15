using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Akka.Common
{


    public static class ProcessingColors
    {
        public static readonly Color IDLE = Colors.LightSalmon;
        public static readonly Color RUNNING = Colors.Red;
        public static readonly Color COMPLETED = Colors.DarkGreen;
        public static readonly Color EXCEPTION = Colors.Black;

        public static SolidColorBrush IdleBrush
        {
            get
            {
                return new SolidColorBrush(IDLE);
            }
        }

        public static SolidColorBrush RunningBrush
        {
            get
            {
                return new SolidColorBrush(RUNNING);
            }
        }

        public static SolidColorBrush CompletedBrush
        {
            get
            {
                return new SolidColorBrush(COMPLETED);
            }
        }

        public static SolidColorBrush ExceptionBrush
        {
            get
            {
                return new SolidColorBrush(EXCEPTION);
            }
        }



        public static Color ToColor(this ProcessStatus status)
        {
            Color col = Colors.Black;
            switch (status)
            {
                case ProcessStatus.Idle:
                    return IDLE;
                case ProcessStatus.Running:
                    return RUNNING;
                case ProcessStatus.Completed:
                    return COMPLETED;
                case ProcessStatus.Exception:
                    return EXCEPTION;
                default:
                    return IDLE;
            }
        }

    }
}
