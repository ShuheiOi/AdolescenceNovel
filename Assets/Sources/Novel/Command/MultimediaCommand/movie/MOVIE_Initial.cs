/*
MIT License

Copyright (c) 2022 ShuheiOi

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
namespace AdolescenceNovel
{
    public class MOVIE_Initial : IMovieState
    {
        private static MOVIE_Initial _singleton = null;
        public static MOVIE_Initial singleton
        {
            get
            {
                if(_singleton == null)
                {
                    _singleton = new MOVIE_Initial();
                }
                return _singleton;
            }
        }
        public bool Execute(Movie nowstate, MovieContext context)
        {
            ConstData.instance.videoPlayer.gameObject.SetActive(true);
            ConstData.instance.videoImage.enabled = false;
            string movie_name = (string)nowstate.movieName.Value();
            ConstData.instance.videoPlayer.clip = Resources.Load<VideoClip>((string)nowstate.movieName.Value());
            ConstData.instance.videoPlayer.time = 0f;
            ConstData.instance.videoPlayer.Prepare();
            context.ChangeStatus(new MOVIE_Wait());
            return false;
        }
    }
}