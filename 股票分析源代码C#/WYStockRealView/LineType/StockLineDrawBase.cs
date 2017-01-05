using System;
using ICollection = System.Collections.ICollection;
using System.Collections;
using ZedGraph;
namespace WYStockRealView.LineType
{

   	/// <summary>
	/// An implementation of the things necessary for most ZedGraphDemos.
	/// </summary>
	public abstract class StockLineDrawBase : ZedGraphDemo
	{
		protected string description;
		protected string title;
		protected ICollection types;
		
		private ZedGraphControl control;

		public StockLineDrawBase( string description, string title, DemoType type )
		{
			ArrayList types = new ArrayList();
			types.Add( type );

			Init( description, title, types );
		}
		
		public StockLineDrawBase( string description, string title, DemoType type, DemoType type2 )
		{
			ArrayList types = new ArrayList();
			types.Add( type );
			types.Add( type2 );

			Init( description, title, types );
		}

        public StockLineDrawBase(string description, string title, ICollection types) 
		{
			Init( description, title, types );
		}
		
		private void Init( string description, string title, ICollection types )
		{
			this.description = description;
			this.title = title;
			this.types = types;

			control = new ZedGraphControl();
		}

	#region ZedGraphDemo Members

		/// <summary>
		/// The graph pane the chart is show in.
		/// </summary>
		public PaneBase Pane { get { return control.GraphPane; } }
		
		/// <summary>
		/// The graph pane the chart is show in.
		/// </summary>
		public MasterPane MasterPane { get { return control.MasterPane; } }

		/// <summary>
		/// The graph pane the chart is show in (same as .Pane).
		/// </summary>
		public GraphPane GraphPane { get { return control.GraphPane; } }

		public virtual string Description { get { return description; } }

		public virtual string Title { get { return title; } }

		public virtual ICollection Types { get { return types; } }
		
		/// <summary>
		/// The control the graph pane is in.
		/// </summary>
		public ZedGraphControl ZedGraphControl
		{
			get { return control; }
		}

	#endregion

	}
    public interface ZedGraphDemo
    {
        /// <summary>
        /// A description of what this demo is showing.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The demo's title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// The control used to display this demo.
        /// </summary>
        ZedGraphControl ZedGraphControl { get; }

        /// <summary>
        /// A collection of DemoType objects that this demo applies to.
        /// </summary>
        System.Collections.ICollection Types { get; }
        // string Source { get; }
        // string SourceFileName { get; }
    }
    public enum DemoType
    {
        General,
        Bar,
        Line,
        Pie,
        Special,
        Tutorial
    }
}
