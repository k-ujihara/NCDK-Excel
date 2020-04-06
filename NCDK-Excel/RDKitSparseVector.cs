using GraphMolWrap;
using Newtonsoft.Json;
using RDKit;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCDKExcel
{
    [JsonObject]
    public class RDKitSparseVector
    {
        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("nonzero")]
        public IDictionary<long, int> Nonzero { get; set; }

        public static RDKitSparseVector FromSIV(SparseIntVect32 vector)
        {
            var o = new RDKitSparseVector()
            {
                Size = vector.Count(),
            };
            o.Nonzero = new Dictionary<long, int>();
            foreach (var e in vector.GetNonzero())
            {
                o.Nonzero.Add(e.first, e.second);
            }
            return o;
        }

        public static RDKitSparseVector FromSIV(SparseIntVect64 vector)
        {
            var o = new RDKitSparseVector()
            {
                Size = vector.Count(),
            };
            o.Nonzero = new Dictionary<long, int>();
            foreach (var e in vector.getNonzero())
            {
                o.Nonzero.Add(e.first, e.second);
            }
            return o;
        }

        public static RDKitSparseVector FromJson(string json)
        {
            var sv = JsonConvert.DeserializeObject<RDKitSparseVector>(json);
            return sv;
        }

        public static SparseIntVect64 FromJsonToSIV(string json)
        {
            var sv = FromJson(json);
            var siv = new SparseIntVect64(sv.Size);
            foreach (var e in sv.Nonzero)
                siv.setVal(e.Key, e.Value);
            return siv;
        }

        public static string ToJson(SparseIntVect32 vector)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append($"\"size\":{vector.size()},");
            sb.Append("\"nonzero\":{");
            sb.Append(string.Join(",", vector.getNonzero().Select(n => $"{n.first}:{n.second}")));
            sb.Append("}}");
            return sb.ToString();
        }

        public static string ToJson(SparseIntVectu32 vector)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append($"\"size\":{vector.size()},");
            sb.Append("\"nonzero\":{");
            sb.Append(string.Join(",", vector.GetNonzero().Select(n => $"{n.first}:{n.second}")));
            sb.Append("}}");
            return sb.ToString();
        }

        public static string ToJson(SparseIntVect64 vector)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append($"\"size\":{vector.Count()},");
            sb.Append("\"nonzero\":{");
            sb.Append(string.Join(",", vector.GetNonzero().Select(n => $"{n.first}:{n.second}")));
            sb.Append("}}");
            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append($"\"size\":{Size},");
            sb.Append("\"nonzero\":{");
            sb.Append(string.Join(",", Nonzero.Select(n => $"{n.Key}:{n.Value}")));
            sb.Append("}}");
            return sb.ToString();
        }
    }
}
