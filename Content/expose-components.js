import React from 'react';
import ReactDOM from 'react-dom';
import ReactDOMServer from 'react-dom/server';

import MainPageApp from './MainPage/script.jsx';
import Helmet from 'react-helmet';

global.React = React;
global.ReactDOM = ReactDOM;
global.ReactDOMServer = ReactDOMServer;

global.Helmet = Helmet;

global.Components = { MainPageApp };