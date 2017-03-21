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
            knockout: appDirectory + '/Libs/knockout',
            pager: appDirectory + '/Libs/pager',
            jquery: appDirectory + '/Libs/jquery'
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
            }
        ]
    },
    devtool: "eval-source-map",
    plugins: [
        new webpack.ProvidePlugin({
            $: "jquery",
            ko: "knockout"
        }),
        new webpack.optimize.CommonsChunkPlugin({
            names: ['libs', 'manifest']
        }),
        extractSass
    ]
};