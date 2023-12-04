import { useMutation, useQueryClient } from '@tanstack/react-query';
import { useNavigate } from 'react-router-dom';
import { createEditPost } from '../services/apiPosts';

export const useEditPost = () => {
  const navigate = useNavigate();
  const queryClient = useQueryClient();

  const { mutate: editPost, isLoading: isEditing } = useMutation({
    mutationFn: createEditPost,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['posts'] });
      navigate('/posts');
    },
    onError: err => {
      console.log({ err });
    },
  });

  return { isEditing, editPost };
};
