import React from 'react';
/////////////////COLOR PALETTE ///////////////////////

/**
 * Defines color scheme used within the app. Do not define any other colors anywhere else.
 * if there is a need for a new color, add it's definition here. 
 */
export const SmertPalette = 
{
    PrimaryColor            : '#5761d1',           // Color displayed most frequently across app's screens and components. Brand representation color. 
    SecondaryColor          : '#57d6cd',           // used to accent UI elemnts. 
    OnPrimaryColor          : '#9aa0e4',           // used when the cursor is over UI element with primary color
    OnSecondaryColor        : '#a3e8e4',           // used when the cursor is over UI element with secondary color
    BackgroundColor         : '#FFFFFF',           // used to paint area behind scrollable content
    SurfaceColor            : '#FFFFFF',           // used on container components such as cards, sheets, and menus. Should be different than background color
    OnSurfaceColor          : '#c9ccd1',           //  used when the cursor is over component that uses surface color
    SuccessColor            : '#00a128',           // used to indicate a success 
    WarningColor            : '#a16e00',           // used to indicate a warning 
    ErrorColor              : '#a10000',           // used to indicate an error
    TextColor               : '#5c5757',           // text color
    LinkColor               : '#2865de'            // used to paint links

}

/**
 * Defines orientation of the content within different components. 
 */
export const Orientation = 
{
    Horizontal : 0,
    Vertical   : 1,
    LeftToRight: 2,
    RightToleft: 3,
}

