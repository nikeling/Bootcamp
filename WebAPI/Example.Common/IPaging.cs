﻿namespace Example.Common
{
    public interface IPaging
    {
        int PageNumber { get; set; }
        int RecordsPerPage { get; set; }
    }
}