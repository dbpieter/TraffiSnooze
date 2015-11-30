using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraffiSnooze.Data.ExternalModels.Waze
{

    public class Rootobject
    {
        public Response response { get; set; }
        public Coord[] coords { get; set; }
        public object segCoords { get; set; }
    }

    public class Response
    {
        public Result[] results { get; set; }
        public string[] streetNames { get; set; }
        public object[] tileIds { get; set; }
        public object[] tileUpdateTimes { get; set; }
        public object geom { get; set; }
        public int fromFraction { get; set; }
        public float toFraction { get; set; }
        public bool sameFromSegment { get; set; }
        public bool sameToSegment { get; set; }
        public object astarPoints { get; set; }
        public object wayPointIndexes { get; set; }
        public object wayPointFractions { get; set; }
        public int tollMeters { get; set; }
        public int preferedRouteId { get; set; }
        public bool isInvalid { get; set; }
        public bool isBlocked { get; set; }
        public string serverUniqueId { get; set; }
        public bool displayRoute { get; set; }
        public int astarVisited { get; set; }
        public string astarResult { get; set; }
        public object astarData { get; set; }
        public bool isRestricted { get; set; }
        public string avoidStatus { get; set; }
        public object dueToOverride { get; set; }
        public object segGeoms { get; set; }
        public string routeName { get; set; }
    }

    public class Result
    {
        public Path path { get; set; }
        public int street { get; set; }
        public object altStreets { get; set; }
        public int distance { get; set; }
        public int length { get; set; }
        public int crossTime { get; set; }
        public int crossTimeWithoutRealTime { get; set; }
        public object tiles { get; set; }
        public object clientIds { get; set; }
        public Instruction instruction { get; set; }
        public bool knownDirection { get; set; }
        public int penalty { get; set; }
        public int roadType { get; set; }
        public object additionalInstruction { get; set; }
        public bool isToll { get; set; }
        public object naiveRoute { get; set; }
        public int detourSavings { get; set; }
        public int detourSavingsNoRT { get; set; }
        public bool useHovLane { get; set; }
    }

    public class Path
    {
        public int segmentId { get; set; }
        public int nodeId { get; set; }
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Instruction
    {
        public string opcode { get; set; }
        public int arg { get; set; }
        public object instructionText { get; set; }
        public object name { get; set; }
        public object tts { get; set; }
    }

    public class Coord
    {
        public float x { get; set; }
        public float y { get; set; }
        public string z { get; set; }
    }


}
