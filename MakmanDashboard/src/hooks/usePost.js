import { useQuery } from '@tanstack/react-query';
import { useParams } from 'react-router-dom';
import { getPost } from '../services/apiPosts';

export const usePost = () => {
  const { postId } = useParams();
  const {
    isLoading,
    data: post,
    error,
  } = useQuery({
    queryKey: ['post', postId],
    queryFn: () => getPost(postId),
    retry: true,
  });

  return { isLoading, error, post };
};
