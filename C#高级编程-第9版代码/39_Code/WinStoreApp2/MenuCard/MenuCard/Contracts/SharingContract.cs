using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;
using Wrox.ProCSharp.Model;
using Wrox.ProCSharp.Extensions;

namespace Wrox.ProCSharp.Contracts
{
  class SharingContract : IDisposable
  {
    private MenuCard card;
    DataTransferManager manager;
    public void ShareMenuCard(MenuCard card)
    {
      this.card = card;
      manager = DataTransferManager.GetForCurrentView();
      manager.DataRequested += OnMenuCardRequested;
    }

    private void OnMenuCardRequested(DataTransferManager sender,
      DataRequestedEventArgs args)
    {
      Uri baseUri = new Uri("ms-appx:///");
      DataPackage package = args.Request.Data;
      package.Properties.Title = string.Format("MENU card {0}", card.Title);
      if (card.Description != null)
        package.Properties.Description = card.Description;
      package.Properties.Thumbnail = RandomAccessStreamReference.CreateFromUri(
        new Uri(baseUri, "Assets/Logo.png"));
      package.SetHtmlFormat(HtmlFormatHelper.CreateHtmlFormat(
        card.ToHtml()));
    }

    public void Dispose()
    {
      if (manager != null)
        manager.DataRequested -= OnMenuCardRequested;
    }

  }
}
