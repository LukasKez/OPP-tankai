using System;
using System.Collections.Generic;

namespace Client
{
    public class TransformLeaf : TransformBase
    {
        public TransformLeaf(float x = 0, float y = 0, float w = 1, float h = 1, float r = 0) : base(x, y, w, h, r)
        {
        }

        public TransformLeaf(TransformLeaf transform) : base(transform)
        {
        }

        public override IEnumerator<TransformBase> GetEnumerator()
        {
            yield return this;
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            GameState.Instance.gameLevel?.Remove(gameObject);
        }
    }
}
