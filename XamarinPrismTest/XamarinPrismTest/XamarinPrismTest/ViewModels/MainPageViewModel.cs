using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinPrismTest.Models;

namespace XamarinPrismTest.ViewModels {
  public class MainPageViewModel : ViewModelBase {
    public DelegateCommand NavigateToBlogCommand { get; private set; }

    private List<Blog> _blogs = new List<Blog>()
    {
        new Blog
        {
            BlogDescription = "olestie lectus rhoncus non. Ut eget metus neque. Cras laoreet quam ligula, in ultricies enim lobortis vitae. Proin sed justo vel quam luctus bibendum. Praesent gravida vehicula nunc, eu aliquet elit vestibulum non. Aliquam aliquam fringilla nunc, eget tincidunt dui finibus vel.",
            BlogTitle = "Blog 1",
            CreatedDate = DateTime.Now,
            CreatedBy = "Ryan Nguyen"
        },
        new Blog
        {
            BlogDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam a sollicitudin erat. Vestibulum dapibus sagittis risus, sit amet molestie lectus rhoncus non. Ut eget metus neque. Cras laoreet quam ligula, in ultricies enim lobortis vitae. Proin sed justo vel quam luctus bibendum. Praesent gravida vehicula nunc, eu aliquet elit vestibulum non. Aliquam aliquam fringilla nunc, eget tincidunt dui finibus vel. Ut fermentum viverra justo, a vehicula dui dignissim non. Aenean posuere vestibulum felis, eu fringilla nulla. Nam interdum enim nec risus cursus tempus. Integer vestibulum hendrerit metus, a venenatis justo molestie at. Vestibulum nec libero in velit pulvinar pretium non in enim. Nulla pulvinar auctor dolor, eu laoreet quam vehicula nec. Cras vehicula fringilla massa, vitae molestie lectus dignissim sed. Integer suscipit auctor est, eu bibendum turpis aliquam vitae.",
            BlogTitle = "Blog 2",
            CreatedDate = new DateTime(2017,12,30),
            CreatedBy = "Adam Costenbader"
        },
        new Blog
        {
            BlogDescription = "Etiam a sollicitudin erat. Vestibulum dapibus sagittis risus, sit amet molestie lectus rhoncus non. Ut eget metus neque. Cras laoreet quam ligula, in ultricies enim lobortis vitae. Proin sed justo vel quam luctus bibendum. Praesent gravida vehicula nunc, eu aliquet elit vestibulum non. Aliquam aliquam fringilla nunc, eget tincidunt dui finibus vel. Ut fermentum viverra justo, a vehicula dui dignissim non. Aenean posuere vestibulum felis, eu fringilla nulla. Nam interdum enim nec risus cursus tempus. Integer vestibulum hendrerit metus, a venenatis justo molestie at. Vestibulum nec libero in velit pulvinar pretium non in enim. Nulla pulvinar auctor dolor, eu laoreet quam vehicula nec. Cras vehicula fringilla massa, vitae molestie lectus dignissim sed. Integer suscipit auctor est, eu bibendum turpis aliquam vitae.",
            BlogTitle = "Blog 3",
            CreatedDate = new DateTime(2017,11,30),
            CreatedBy = "Rusty Divine"
        },
        new Blog
        {
            BlogDescription = "molestie lectus rhoncus non. Ut eget metus neque. Cras laoreet quam ligula, in ultricies enim lobortis vitae. Proin sed justo vel quam luctus bibendum. Praesent gravida vehicula nunc, eu aliquet elit vestibulum non. Aliquam aliquam fringilla nunc, eget tincidunt dui finibus vel. Ut fermentum viverra justo, a vehicula dui dignissim non. Aenean posuere vestibulum felis, eu fringilla nulla. Nam interdum enim nec risus cursus tempus. Integer vestibulum hendrerit metus, a venenatis justo molestie at. Vestibulum nec libero in velit pulvinar pretium non in enim. Nulla pulvinar auctor dolor, eu laoreet quam vehicula nec. Cras vehicula fringilla massa, vitae molestie lectus dignissim sed. Integer suscipit auctor est, eu bibendum turpis aliquam vitae.",
            BlogTitle = "Blog 4",
            CreatedDate = new DateTime(2017,10,30),
            CreatedBy = "Linh Nguyen"
        },
    };

    private Blog _selectedBlog;
    public Blog SelectedBlog {
      get { return _selectedBlog; }
      set { SetProperty(ref _selectedBlog, value); }
    }
    public List<Blog> Blogs {
      get { return _blogs; }
      set { SetProperty(ref _blogs, value); }
    }

    public MainPageViewModel(INavigationService navigationService)
        : base(navigationService) {
      Title = "Blogs";

      NavigateToBlogCommand = new DelegateCommand(NavigateToBlog, () => SelectedBlog != null).ObservesProperty(() => SelectedBlog);
    }

    private void NavigateToBlog() {
      var parameter = new NavigationParameters {
        { "Blog", SelectedBlog }
      };

      NavigationService.NavigateAsync("Blog", parameter);
    }
  }
}
