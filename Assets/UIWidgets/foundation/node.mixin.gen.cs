namespace UIWidgets.foundation {

 


    public class AbstractNode  {
        public int depth {
            get { return this._depth; }
        }

        int _depth = 0;

        protected void redepthChild(AbstractNode child) {
            D.assert(child.owner == this.owner);
            if (child._depth <= this._depth) {
                child._depth = this._depth + 1;
                child.redepthChildren();
            }
        }

        public virtual void redepthChildren() {
        }

        public object owner {
            get { return this._owner; }
        }

        object _owner;

        public bool attached {
            get { return this._owner != null; }
        }

        public virtual void attach(object owner) {
            D.assert(owner != null);
            D.assert(this._owner == null);
            this._owner = owner;
        }

        public virtual void detach() {
            D.assert(this._owner != null);
            this._owner = null;
        }

        public AbstractNode parent {
            get { return this._parent; }
        }

        AbstractNode _parent;

        protected virtual void adoptChild(AbstractNode child) {
            D.assert(child != null);
            D.assert(child._parent == null);
            D.assert(() => {
                var node = this;
                while (node.parent != null)
                    node = node.parent;
                D.assert(node != child); // indicates we are about to create a cycle
                return true;
            });

            child._parent = this;
            if (this.attached) {
                child.attach(this._owner);
            }

            this.redepthChild(child);
        }

        protected virtual void dropChild(AbstractNode child) {
            D.assert(child != null);
            D.assert(child._parent == this);
            D.assert(child.attached == this.attached);

            child._parent = null;
            if (this.attached) {
                child.detach();
            }
        }
    }


 


    public class AbstractNodeMixinDiagnosticableTree  : DiagnosticableTree {
        public int depth {
            get { return this._depth; }
        }

        int _depth = 0;

        protected void redepthChild(AbstractNodeMixinDiagnosticableTree child) {
            D.assert(child.owner == this.owner);
            if (child._depth <= this._depth) {
                child._depth = this._depth + 1;
                child.redepthChildren();
            }
        }

        public virtual void redepthChildren() {
        }

        public object owner {
            get { return this._owner; }
        }

        object _owner;

        public bool attached {
            get { return this._owner != null; }
        }

        public virtual void attach(object owner) {
            D.assert(owner != null);
            D.assert(this._owner == null);
            this._owner = owner;
        }

        public virtual void detach() {
            D.assert(this._owner != null);
            this._owner = null;
        }

        public AbstractNodeMixinDiagnosticableTree parent {
            get { return this._parent; }
        }

        AbstractNodeMixinDiagnosticableTree _parent;

        protected virtual void adoptChild(AbstractNodeMixinDiagnosticableTree child) {
            D.assert(child != null);
            D.assert(child._parent == null);
            D.assert(() => {
                var node = this;
                while (node.parent != null)
                    node = node.parent;
                D.assert(node != child); // indicates we are about to create a cycle
                return true;
            });

            child._parent = this;
            if (this.attached) {
                child.attach(this._owner);
            }

            this.redepthChild(child);
        }

        protected virtual void dropChild(AbstractNodeMixinDiagnosticableTree child) {
            D.assert(child != null);
            D.assert(child._parent == this);
            D.assert(child.attached == this.attached);

            child._parent = null;
            if (this.attached) {
                child.detach();
            }
        }
    }


}