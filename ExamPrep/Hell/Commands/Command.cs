using System;
using System.Collections.Generic;

public abstract class Command : IExecutable
{
    private IList<string> data;
    private IManager manager;

    protected Command(IList<string> data, IManager manager)
    {
        this.Data = data;
        this.Manager = manager;
    }

    public IList<string> Data
    {
        protected get
        {
            return this.data;
        }
        set
        {
            this.data = value;
        }
    }

    public IManager Manager
    {
        get
        {
            return this.manager;
        }
        private set
        {
            this.manager = value;
        }
    }

    public abstract string Execute();
}
