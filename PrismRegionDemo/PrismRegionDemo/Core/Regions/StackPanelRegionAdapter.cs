﻿using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismRegionDemo.Core.Regions
{
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(RegionBehaviorFactory behaviorFactory)
            : base (behaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement item in e.NewItems)
                    {
                        regionTarget.Children.Add(item);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement item in e.OldItems)
                    {
                        regionTarget.Children.Remove(item);
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
