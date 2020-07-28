using RimWorld;
using UnityEngine;
using Verse;
using static Hospitality.RelationUtility;

namespace Hospitality.MainTab
{
    [StaticConstructorOnStartup]
    public class PawnColumnWorker_Relationship : PawnColumnWorker_Icon
    {
        private static readonly Texture2D Icon = ContentFinder<Texture2D>.Get("UI/Tab/Relationship");
        private bool mayDrawLordGroups;

        protected override Texture2D GetIconFor(Pawn pawn)
        {
            if (pawn == null) return null;
            return GetRelationInfo(pawn).hasRelationship ? Icon : null;
        }

        protected override string GetIconTip(Pawn pawn)
        {
            return GetRelationInfo(pawn).tooltip;
        }

        public override void DoCell(Rect rect, Pawn pawn, PawnTable table)
        {
            base.DoCell(rect, pawn, table);

            // Only run once
            if (!mayDrawLordGroups) return;
            mayDrawLordGroups = false;

            MainTabUtility.DrawLordGroups(rect, table, pawn);
        }

        public override void DoHeader(Rect rect, PawnTable table)
        {
            base.DoHeader(rect, table);
            mayDrawLordGroups = true;
        }
    }
}
