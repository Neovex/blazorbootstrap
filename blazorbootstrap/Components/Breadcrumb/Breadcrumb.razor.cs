﻿namespace BlazorBootstrap;

public partial class Breadcrumb : BlazorBootstrapComponentBase
{
    #region Methods

    protected string? ClassNames => new CssClassBuilder(Class).Build();

    protected string? StyleNames => new CssStyleBuilder(Style).Build();

    protected override ValueTask DisposeAsyncCore(bool disposing)
    {
        if (disposing)
            if (BreadcrumbService is not null)
                BreadcrumbService.OnNotify -= OnNotify;

        return base.DisposeAsyncCore(disposing);
    }

    protected override void OnInitialized()
    {
        if (BreadcrumbService is not null)
            BreadcrumbService.OnNotify += OnNotify;

        base.OnInitialized();
    }

    private void OnNotify(List<BreadcrumbItem> items)
    {
        if (items is null)
            return;

        Items ??= new List<BreadcrumbItem>();

        Items = items;

        StateHasChanged();
    }

    #endregion

    #region Properties, Indexers

    [Inject] private BreadcrumbService BreadcrumbService { get; set; } = default!;

    /// <summary>
    /// List of all the items.
    /// </summary>
    [Parameter]
    public List<BreadcrumbItem> Items { get; set; } = default!;

    #endregion
}
