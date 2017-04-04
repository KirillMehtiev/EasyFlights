"use strict";

const webpack = require("webpack");
const path = require("path");
var ExtractTextPlugin = require("extract-text-webpack-plugin");

const extractSass = new ExtractTextPlugin({
    filename: "[name].css"
});
const appDirectory = path.resolve("./Client/");
var dependencies = Object.keys(require('./package').dependencies);

module.exports = {
    context: appDirectory,
    resolve: {
        alias: {
            pager: appDirectory + '/Libs/js/pager',
            'jquery-ui': appDirectory + '/Libs/js/jquery-ui',
            jqueryCookie: appDirectory + '/Libs/js/jquery.cookie',
            blockUI: appDirectory + '/Libs/js/jquery.blockUI'
        },
        extensions: ['.ts', '.tsx', '.js']
    },
    entry: {
        libs: dependencies,
        app: "./App/App.ts"
    },
    output: {
        path: appDirectory + "/dist",
        filename: "[name].bundle.js"
    },
    module: {
        rules: [
            {
                test: /\.html$/,
                use: 'raw-loader'
            },
            {
                test: /\.tsx?$/,
                loader: 'ts-loader'
            },
            {
                test: /\.scss$/,
                use: extractSass.extract({
                    use: [{
                        loader: "css-loader"
                    }, {
                        loader: "sass-loader"
                    }]
                })
            },
            {
                test: /\.css$/,
                use: extractSass.extract({
                    fallback: "style-loader",
                    use: "css-loader"
                })
            },
            {
                test: /\.(ttf|eot|svg|woff(2)?)(\?[a-z0-9]+)?$/,
                loader: 'file-loader',
            }
        ]
    },
    devtool: "eval-source-map",
    plugins: [
        new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery",
            ko: "knockout"
        }),
        new webpack.optimize.CommonsChunkPlugin({
            names: ['libs', 'manifest']
        }),
        extractSass
    ]
};